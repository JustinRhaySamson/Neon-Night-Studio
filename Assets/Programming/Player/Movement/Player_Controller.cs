using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Collider attack;
    private Vector3 _input;
    Animator animator;

    public LayerMask enemy;
    bool attacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        if (!attacking)
        {
            transform.rotation = rot;
        }
    }

    private void Move()
    {
        //_rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        if (_input != Vector3.zero)
        {
            animator.SetFloat("Running", 1);
        }
        else if (_input == Vector3.zero)
        {
            animator.SetFloat("Running", 0);
        }
    }
    public void Attack_A(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            animator.SetBool("Attack1", true);
            StartCoroutine(Finish_Animation(1f, "Attack1"));
            attacking = true;
            //attack.enabled = true;
        }
        /*else if (callbackContext.canceled)
        {
            animator.SetBool("Attack1", false);
        }*/
    }

    public void Attack_B(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            animator.SetBool("Attack2", true);
            StartCoroutine(Finish_Animation(1.5f, "Attack2"));
            //attack.enabled = true;
            attacking = true;
        }
        /*else if (callbackContext.canceled)
        {
            animator.SetBool("Attack2", false);
        }*/
    }

    IEnumerator Finish_Animation(float time, string anim_name)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool(anim_name, false);
        //attack.enabled = false;
        attacking = false;

    }

    public void Dash()
    {
        gameObject.tag = "Invincible";
        animator.SetFloat("Dash_Speed", 2.5f);
        //animator.SetBool("Dash", true);
        StartCoroutine(Dash_Speedup(.3f));
    }

    IEnumerator Dash_Speedup(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetFloat("Dash_Speed", 1);
        //animator.SetBool("Dash", false);
        gameObject.tag = "Player";
    }
}

