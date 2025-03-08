using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Idle_State : Boss2_Base_State
{
    public override void EnterState(Boss2_State_Manager state)
    {
        state.animator.SetBool("Intro", true);
        state.animator.SetBool("Running", true);
    }

    public override void UpdateState(Boss2_State_Manager state)
    {

    }

    public override void OnTriggerEnter(Boss2_State_Manager state)
    {
        /*switch (state.random_number)
        {
            case 0:
                state.SwitchState(state.flash_Step);
                break;
            case 1:
                state.SwitchState(state.cross_Lightning);
                break;
            case 2:
                state.SwitchState(state.slash_state);
                break;
        }*/

    }

    public override void OnTriggerExit(Boss2_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss2_State_Manager state)
    {
        
    }

    public override void Timer_Inside_Trigger(Boss2_State_Manager state)
    {
        /*if (state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    state.SwitchState(state.flash_Step);
                    break;
                case 1:
                    state.SwitchState(state.cross_Lightning);
                    break;
                case 2:
                    state.SwitchState(state.slash_state);
                    break;
            }
        }

        else if (!state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    state.SwitchState(state.thunderfall);
                    break;
                case 1:
                    if (state.attacks_made >= 5)
                    {
                        state.SwitchState(state.dash2);
                    }
                    break;
                case 2:
                    state.SwitchState(state.scatter_Bolt);
                    break;
            }
        }*/
    }
}
