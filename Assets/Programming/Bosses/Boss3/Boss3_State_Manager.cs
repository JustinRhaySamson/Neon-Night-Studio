using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_State_Manager : MonoBehaviour
{
    Boss3_Base_State currentState;

    public Boss3_idle_State idle_state = new Boss3_idle_State();
    public Boss3_Inactive_State inactive_state = new Boss3_Inactive_State();
    public Boss3_Advancing_Frost_State advancing_frost = new Boss3_Advancing_Frost_State();
    public Boss3_Right_Shattering_State right_shattering = new Boss3_Right_Shattering_State();
    public Boss3_Left_Shattering_State left_shattering = new Boss3_Left_Shattering_State();
    public Boss3_Flash_Freeze_State flash_freeze = new Boss3_Flash_Freeze_State();
    public Boss3_Dash_State dash_State = new Boss3_Dash_State();
    public Boss3_Walls_State walls_State = new Boss3_Walls_State();


    public GameObject player;
    public Animator animator;
    public int random_number = 0;
    public int chain_attack = 1;
    public int attacks_made = 0;
    public int random_chain_attack = 1;
    public bool inside_trigger = false;
    public Look_At look_at;
    public Transform arena_center;
    public int force = 5000;
    public GameObject dash_VFX;
    [HideInInspector] public Transform point_to_look;
    [HideInInspector] public int shoulder_count = 0;

    public GameObject[] ice_wall_teleports;
    public Transform[] ice_wall_look;
    Teleporter_Script[] teleporter_scripts;
    public GameObject teleports_parent;

    public bool dashing_to_center = false;
    [SerializeField] bool phase2 = false;

    Boss3_Projectile_Spawn projectile_Spawn;
    GameObject ice_wall;
    

    public int walls_broken = 0;


    void Start()
    { 
        look_at = gameObject.GetComponent<Look_At>();
        print("wtf");
        projectile_Spawn = gameObject.GetComponent<Boss3_Projectile_Spawn>();
        currentState = inactive_state;
        currentState.EnterState(this);
        StartCoroutine(Timer());
        if (phase2)
        {
            animator.SetBool("Phase2", true);
            //currentState = phase2_idle_state;
            currentState.EnterState(this);
        }
        for (int i = 0; i < ice_wall_teleports.Length; i++)
        {
            teleporter_scripts[i] = ice_wall_teleports[i].GetComponent<Teleporter_Script>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        //print(point_to_look);
    }

    private void FixedUpdate()
    {
        if (dashing_to_center)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
            look_at.Look_At_Center(arena_center);
        }
    }

    public void SwitchState(Boss3_Base_State state)
    {
        currentState = state;
        print("The current state is " + currentState.ToString());
        state.EnterState(this);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            currentState.OnCollisionEnter(this);
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
            random_number = Random.Range(0, 2);
            //print("The random number is " + random_number);
            currentState.Timer_Inside_Trigger(this);
        }
    }

    public void Back_To_Idle()
    {
        currentState = idle_state;
        currentState.EnterState(this);
    }

    /*public void Back_To_Idle2()
    {
        currentState = phase2_idle_state;
        currentState.EnterState(this);
    }*/

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

    public void Look_At_Wall()
    {
        look_at.Look_At_Center(point_to_look);
    }

    public void Look_Player()
    {
        look_at.Look_At_Player();
    }
    public void Teleport_To_Wall()
    {
        transform.position = ice_wall_teleports[walls_broken].transform.position;
        look_at.Look_At_Center(ice_wall_look[walls_broken]);
        walls_broken++;
    }

    public void Break_Wall()
    {
        ice_wall = projectile_Spawn.ice_walls_spawn;
        Animator ice_animator = ice_wall.GetComponent<Animator>();
        ice_animator.SetInteger("Walls_Broken", walls_broken);
    }

    public void Reset_Walls_Broken()
    {
        walls_broken = 0;
    }

    public void All_Walls_Broken()
    {
        if(walls_broken > 5)
        {
            Back_To_Idle();
        }
    }
}
