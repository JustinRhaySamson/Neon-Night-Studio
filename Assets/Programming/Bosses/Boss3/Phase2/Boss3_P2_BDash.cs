using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_P2_BDash : Boss3_Base_State
{
    public override void EnterState(Boss3_State_Manager state)
    {
        state.animator.SetBool("Dash", true);
        //state.trigger_sphere.enabled = false;
        //state.dashing_to_center = true;
    }

    public override void UpdateState(Boss3_State_Manager state)
    {
        if (state.animator.GetBool("Dash"))
        {
            state.dashing_to_center = true;
        }
        if (state.transform.position.x <= state.arena_center.position.x + 1
            && state.transform.position.x >= state.arena_center.position.x - 1
            && state.transform.position.z <= state.arena_center.position.z + 1
            && state.transform.position.z >= state.arena_center.position.z - 1)
        {
            Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            state.dashing_to_center = false;
            state.SwitchState(state.blizzard_state);
        }
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
