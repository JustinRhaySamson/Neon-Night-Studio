using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Idle_State : Boss2_Base_State
{
    public override void EnterState(Boss2_State_Manager state)
    {
        state.animator.SetBool("Cyclonic_Slash", false);
        //state.animator.SetBool("Storm", false);
        state.animator.SetBool("Spin",false);
        state.animator.SetBool("Boomerang", false);
        state.animator.SetBool("Divine", false);
        if (state.shoulder_count >= 5)
        {
            state.animator.SetBool("Shoulder", false);
        }
        state.animator.SetBool("Intro", true);
        state.animator.SetBool("Running", true);
        state.Look_Player();
    }

    public override void UpdateState(Boss2_State_Manager state)
    {

    }

    public override void OnTriggerEnter(Boss2_State_Manager state)
    {
        switch (state.random_number)
        {
            case 0:
                state.SwitchState(state.cyclonic_Slah);
                break;
            case 1:
                state.SwitchState(state.spin_state);
                break;
            /*case 2:
                state.SwitchState(state.slash_state);
                break;*/
        }

    }

    public override void OnTriggerExit(Boss2_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss2_State_Manager state)
    {
        
    }

    public override void Timer_Inside_Trigger(Boss2_State_Manager state)
    {
        if (state.inside_trigger)
        {
            switch (state.random_number)
            {
                case 0:
                    state.SwitchState(state.cyclonic_Slah);
                    break;
                case 1:
                    state.SwitchState(state.spin_state);
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
                    if (state.attacks_made >= 4)
                    {
                        state.SwitchState(state.wall_state);
                    }
                    break;
                case 1:
                    state.SwitchState(state.boomerang_State);
                    break;
                case 2:
                    state.SwitchState(state.divine_punishment);
                    break;
            }
        }
    }
}
