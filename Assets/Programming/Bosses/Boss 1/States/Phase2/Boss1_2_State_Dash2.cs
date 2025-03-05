using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_2_State_Dash2 : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Dash2", true);
    }

    public override void UpdateState(Boss1_State_Manager state)
    {
        if (state.transform.position.x <= state.room_center.position.x + 1
            && state.transform.position.x >= state.room_center.position.x - 1
            && state.transform.position.z <= state.room_center.position.z + 1
            && state.transform.position.z >= state.room_center.position.z - 1)
        {
            Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            state.SwitchState(state.thunder_Strike);
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
