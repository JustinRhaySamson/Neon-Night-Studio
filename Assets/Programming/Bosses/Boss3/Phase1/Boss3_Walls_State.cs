using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_Walls_State : Boss3_Base_State
{
    public override void EnterState(Boss3_State_Manager state)
    {
        //state.animator.SetBool("Dash", false);
        state.animator.SetBool("Walls", true);
        state.dashing_to_center = false;
        Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        state.attacks_made = 0;
        state.walls_broken = 0;
    }

    public override void UpdateState(Boss3_State_Manager state)
    {
        
    }

    public override void OnTriggerEnter(Boss3_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss3_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss3_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss3_State_Manager state)
    {

    }
}
