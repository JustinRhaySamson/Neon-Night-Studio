using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_2_State_Idle : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Strong_Right", false);
        state.animator.SetBool("Death_Dive", false);
        state.animator.SetBool("Rolling_Thunder", false);
        state.animator.SetBool("Vortex_Of_Pain", false);
        state.animator.SetBool("Dash", false);
        state.animator.SetBool("Thunder_Fall", false);
        state.animator.SetBool("Flash_Step", false);
        state.animator.SetBool("Cross_Lightning", false);
        state.animator.SetBool("Thunder_Strike", false);
        state.animator.SetBool("Dash2", false);
        state.animator.SetBool("Running", true);
    }

    public override void UpdateState(Boss1_State_Manager state)
    {

    }

    public override void OnTriggerEnter(Boss1_State_Manager state)
    {
        switch (state.random_number)
        {
            case 0:
                state.SwitchState(state.flash_Step);
                break;
            case 1:
                state.SwitchState(state.cross_Lightning);
                break;
        }

    }

    public override void OnTriggerExit(Boss1_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss1_State_Manager state)
    {
        if (state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    state.SwitchState(state.flash_Step);
                    break;
                case 1:
                    state.SwitchState(state.cross_Lightning);
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
            }
        }
    }
}
