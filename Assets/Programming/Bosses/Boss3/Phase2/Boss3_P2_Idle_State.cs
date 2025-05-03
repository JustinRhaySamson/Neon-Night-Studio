using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_P2_Idle_State : Boss3_Base_State
{
    public override void EnterState(Boss3_State_Manager state)
    {
        state.animator.SetBool("Advancing_Frost", false);
        state.animator.SetBool("Right_Shattering", false);
        state.animator.SetBool("Left_Shattering", false);
        state.animator.SetBool("Flash_Freeze", false);
        state.animator.SetBool("Dash", false);
        state.animator.SetBool("Walls", false);
        state.animator.SetBool("Right_Slide", false);
        state.animator.SetBool("Left_Slide", false);
        state.animator.SetBool("Blizzard", false);
        state.animator.SetBool("Reflection", false);
        state.animator.SetBool("Start", true);
        state.animator.SetBool("Running", true);
        //state.animator.SetBool("Phase2",true);
        Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        state.trigger_sphere.enabled = true;
    }

    public override void UpdateState(Boss3_State_Manager state)
    {

    }

    public override void OnTriggerEnter(Boss3_State_Manager state)
    {
        switch (state.random_number)
        {
            case 0:
                Vector3 playerDirectionLocal = state.gameObject.transform.InverseTransformPoint(state.player.transform.position);
                if (playerDirectionLocal.x > 0)
                {
                    state.SwitchState(state.right_Slide);
                }
                if (playerDirectionLocal.x < 0)
                {
                    state.SwitchState(state.left_Slide);
                }
                break;
            case 1:
                state.SwitchState(state.reflection_state);
                break;
                /*case 2:
                    state.SwitchState(state.slash_state);
                    break;*/
        }
    }

    public override void OnTriggerExit(Boss3_State_Manager state)
    {
        
    }

    public override void OnCollisionEnter(Boss3_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss3_State_Manager state)
    {
        if (state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    Vector3 playerDirectionLocal = state.gameObject.transform.InverseTransformPoint(state.player.transform.position);
                    if (playerDirectionLocal.x > 0)
                    {
                        state.SwitchState(state.right_Slide);
                    }
                    if (playerDirectionLocal.x < 0)
                    {
                        state.SwitchState(state.left_Slide);
                    }
                    break;
                case 1:
                    state.SwitchState(state.reflection_state);
                    break;
                    /*case 2:
                        state.SwitchState(state.slash_state);
                        break;*/
            }
        }

        else if (!state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    state.SwitchState(state.BDash_state);
                    break;
                case 1:
                    if (state.attacks_made >= 4)
                    {
                        state.SwitchState(state.dash_State);
                    }
                    break;
                    /*case 2:
                        state.SwitchState(state.divine_punishment);
                        break;*/
            }
        }
    }
}