using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Shoulder_Bash_State : Boss2_Base_State
{
    public override void EnterState(Boss2_State_Manager state)
    {
        state.animator.SetBool("Cyclonic_Slash", false);
        state.animator.SetBool("Storm", false);
        state.animator.SetBool("Running", false);
        state.animator.SetBool("Shoulder", true);
        state.shoulder_count = 0;
        state.attacks_made = 0;
    }

    public override void UpdateState(Boss2_State_Manager state)
    {
        if(state.shoulder_count >= 5)
        {
            state.SwitchState(state.idle_state);
        }
    }

    public override void OnTriggerEnter(Boss2_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss2_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss2_State_Manager state)
    {
        state.dashing_to_center = false;
        Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        state.shoulder_count++;
    }

    public override void Timer_Inside_Trigger(Boss2_State_Manager state)
    {

    }
}
