using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Manager : MonoBehaviour
{
    Boss1_Base_State currentState;

    public Boss1_State_Idle idle_state = new Boss1_State_Idle();
    public Boss1_State_Strong_Right strong_Right = new Boss1_State_Strong_Right();
    public Boss1_State_Death_Dive death_Dive = new Boss1_State_Death_Dive();
    public Boos1_State_Rolling_Thunder rolling_Thunder = new Boos1_State_Rolling_Thunder();
    public Boss1_State_Center_Dash center_Dash = new Boss1_State_Center_Dash();
    public Boss1_State_Vortex_Of_Pain vortex_Of_Pain = new Boss1_State_Vortex_Of_Pain();
    public Boss1_State_Inactive inactive_state = new Boss1_State_Inactive();
    public Boss1_State_Anchor_Slam anchor_Slam = new Boss1_State_Anchor_Slam();
    public Boss1_State_Front_Slam front_Slam = new Boss1_State_Front_Slam();
    
    
    public Boss1_2_State_Idle phase2_idle_state = new Boss1_2_State_Idle();
    public Boss1_2_State_Thunderfall thunderfall = new Boss1_2_State_Thunderfall();
    public Boss1_2_State_Flash_Step flash_Step = new Boss1_2_State_Flash_Step();
    public Boss1_2_State_Cross_Lightning cross_Lightning = new Boss1_2_State_Cross_Lightning();
    public Boss1_2_State_Dash2 dash2 = new Boss1_2_State_Dash2();
    public Boss1_2_State_Thunder_Strike thunder_Strike = new Boss1_2_State_Thunder_Strike();
    public Boss1_2_State_Scatter_Bolt scatter_Bolt = new Boss1_2_State_Scatter_Bolt();
    public Boss1_2_State_Slash slash_state = new Boss1_2_State_Slash();

    public Animator animator;
    public int random_number = 0;
    public int chain_attack = 1;
    public int attacks_made = 0;
    public int random_chain_attack = 1;
    public bool inside_trigger = false;
    public Transform room_center;
    public Look_At look_at;
    public int force = 3000;
    public GameObject dash_VFX;


    public bool dashing_to_center = false;
    [SerializeField] bool phase2 = false;

    Boss1_Projectile_Spawn projectile_Spawn;

    
    void Start()
    {
        look_at = gameObject.GetComponent<Look_At>();
        projectile_Spawn = gameObject.GetComponent<Boss1_Projectile_Spawn>();
        currentState = inactive_state;
        currentState.EnterState(this);
        StartCoroutine(Timer());
        if (phase2)
        {
            animator.SetBool("Phase2", true);
            currentState = phase2_idle_state;
            currentState.EnterState(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        if (dashing_to_center)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
            look_at.Look_At_Center(room_center);
        }
    }

    public void SwitchState(Boss1_Base_State state)
    {
        currentState = state;
        state.EnterState(this);
        print("attacks made: " + attacks_made);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            inside_trigger = true;
            random_number = Random.Range(0, 3);
            currentState.OnTriggerEnter(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            inside_trigger = false;
            currentState.OnTriggerExit(this);
        }
    }

    public void Set_Anim_Speed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void Chain_Attack_Up()
    {
        chain_attack++;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.8f);
            //print("The one bool in the state machine is: " + inside_trigger);
            random_number = Random.Range(0, 3);
            currentState.Timer_Inside_Trigger(this);
        }
    }

    public void Back_To_Idle()
    {
        currentState = idle_state;
        currentState.EnterState(this);
    }

    public void Back_To_Idle2()
    {
        currentState = phase2_idle_state;
        currentState.EnterState(this);
    }

    public void Look_At_Center_State()
    {
        dashing_to_center = true;
    }

    public void No_Look_Center()
    {
        dashing_to_center = false;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        Look_At_Player_State();
    }

    public void Look_At_Player_State()
    {
        look_at.Look_At_Player();
    }

    public void Start_Dash_VFX()
    {
        dash_VFX.SetActive(true);
    }
    public void Stop_Dash_VFX()
    {
        dash_VFX.SetActive(false);
    }

    public void Deactivate_Hitbox()
    {
        CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;
    }

    public void Activate_Hitbox()
    {
        CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = true;
    }

    public void Deactivate_Trigger()
    {
        SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
    }

    public void Activate_Trigger()
    {
        SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
        sphereCollider.enabled = true;
    }

    public void Teleport_Player()
    {
        gameObject.transform.position = look_at.player_transform.position;
        projectile_Spawn.Spawn_Big_Lightning();
    }
}
