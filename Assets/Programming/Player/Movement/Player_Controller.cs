using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Collider attack;
    private Vector3 _input;
    public Vector3 public_input;
    Animator animator;

    public LayerMask enemy;
    bool dashing = false;
    bool is_dashing = false;
    bool attacking = false;
    bool attack_chain = false;
    bool healing = false;
    bool active_gravity = false;
    [HideInInspector] public bool dialogue = false;
    bool dead = false;
    bool time_stop = false;

    public GameObject DashVFX;

    public Collider attack_collider;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GatherInput();
        Look();
        if (active_gravity)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        public_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero || dialogue) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        if (!attacking && Time.timeScale != 0 && !dead)
        {
            transform.rotation = rot;
        }
    }

    private void Move()
    {
        //_rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        if (_input != Vector3.zero && !dialogue)
        {
            if (healing == false)
            {
                animator.SetFloat("Running", 1);
            }
            else if (healing)
            {

            }
        }
        else if (_input == Vector3.zero || dialogue)
        {
            animator.SetFloat("Running", 0);
        }
    }
    public void Attack_A(InputAction.CallbackContext callbackContext)
    {
        if (!dialogue)
        {
            if (callbackContext.performed && healing == false && !animator.GetBool("Attack1"))
            {
                animator.SetBool("Attack1", true);
                StartCoroutine(Finish_Animation(.3f, "Attack1"));
                attacking = true;
                //attack.enabled = true;
            }
            if (callbackContext.performed && attack_chain)
            {
                animator.SetBool("AttackFollowUp1", true);
                attacking = true;
                StartCoroutine(Finish_Animation(1f, "Attack1"));
            }
        }
    }

    public void Attack_B(InputAction.CallbackContext callbackContext)
    {
        if (!dialogue)
        {
            if (callbackContext.performed && healing == false)
            {
                animator.SetBool("Attack2", true);
                StartCoroutine(Finish_Animation(1.5f, "Attack2"));
                //attack.enabled = true;
                attacking = true;
            }
        }     
    }

    IEnumerator Finish_Animation(float time, string anim_name)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool(anim_name, false);
        //attack.enabled = false;
        attacking = false;

    }

    public void Dash(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && !dashing)
        {
            gameObject.tag = "Invincible";
            gameObject.layer = LayerMask.NameToLayer("Invincible");
            animator.SetFloat("Dash_Speed", 3.4f);
            dashing = true;
            is_dashing = true;
            //animator.SetBool("Dash", true);
            DashVFX.SetActive(true);
            StartCoroutine(Dash_Speedup(.3f));
            StartCoroutine(Dash_Cooldown(.5f));
        } 
    }

    IEnumerator Dash_Speedup(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetFloat("Dash_Speed", 1.7f);
        //animator.SetBool("Dash", false);
        if (!time_stop)
        {
            gameObject.tag = "Player";
        }
        gameObject.layer = LayerMask.NameToLayer("Player");
        is_dashing = false;
        DashVFX.SetActive(false);
    }

    IEnumerator Dash_Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        dashing = false;
    }

    public void AttackChainTrue()
    {
        attack_chain = true;
    }

    public void AttackChainFalse()
    {
        attack_chain = false;
    }

    public void NoChainAttack()
    {
        animator.SetBool("AttackFollowUp1", false);
    }

    public void NoChainFailed()
    {
        animator.SetBool("AttackChainStop", false);
    }

    public void ChainFailed()
    {
        if (animator.GetBool("AttackFollowUp1") == false)
        {
            animator.SetBool("AttackChainStop", true);
        }
    }

    public void Heal(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            healing = true;
        }
        if (callbackContext.canceled)
        {
            healing = false;
        }
    }

    public void Gravity_Active()
    {
        active_gravity = true;
    }
    public void Gravity_Not_Active()
    {
        active_gravity = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void Change_Dialogue_True()
    {
        dialogue = true;
    }

    public void Change_Dialogue_False()
    {
        dialogue = false;
    }

    public void True_Attack_Collider()
    {
        attack_collider.enabled = true;
    }

    public void False_Attack_Collider()
    {
        attack_collider.enabled = false;
    }

    public void Dead_Bool()
    {
        dead = true;
    }

    public void Stop_Time()
    {
        time_stop = true;
        gameObject.tag = "Invincible";
    }

    public void Reset_Time()
    {
        time_stop = false;
        if (!is_dashing)
        {
            gameObject.tag = "Player";
        }
    }
}

