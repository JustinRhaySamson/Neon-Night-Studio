using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Idle : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Strong_Right", false);
        state.animator.SetBool("Death_Dive", false);
        state.animator.SetBool("Rolling_Thunder", false);
        state.animator.SetBool("Vortex_Of_Pain", false);
        state.animator.SetBool("Dash", false);
        state.animator.SetBool("Anchor_Slam", false);
        state.animator.SetBool("Front_Slam", false);
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
                state.SwitchState(state.strong_Right);
                break;
            case 1:
                state.SwitchState(state.death_Dive);
                break;
            case 2:
                state.SwitchState(state.anchor_Slam);
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
                    state.SwitchState(state.strong_Right);
                    break;
                case 1:
                    state.SwitchState(state.death_Dive);
                    break;
                case 2:
                    if (state.attacks_made >= 7)
                    {
                        state.SwitchState(state.anchor_Slam);
                    }
                    break;
            }
        }

        else if (!state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    state.SwitchState(state.rolling_Thunder);
                    break;
                case 1:
                    if(state.attacks_made >= 5)
                    {
                        state.SwitchState(state.center_Dash);
                    }
                    break;
                case 2:
                    state.SwitchState(state.front_Slam);
                    break;
            }
        }
    }
}
