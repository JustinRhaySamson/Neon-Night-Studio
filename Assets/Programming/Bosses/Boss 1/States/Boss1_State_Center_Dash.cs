using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Center_Dash : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Dash", true);
    }

    public override void UpdateState(Boss1_State_Manager state)
    {
        if(state.transform.position.x <= state.room_center.position.x + 1
            && state.transform.position.x >= state.room_center.position.x - 1
            && state.transform.position.z <= state.room_center.position.z + 1
            && state.transform.position.z >= state.room_center.position.z - 1)
        {
            Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            state.SwitchState(state.vortex_Of_Pain);
        }
    }

    public override void OnTriggerEnter(Boss1_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss1_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss1_State_Manager state)
    {

    }
}
