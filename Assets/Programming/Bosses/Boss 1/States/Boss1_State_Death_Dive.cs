using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Death_Dive : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Death_Dive", true);
        state.chain_attack = 1;
        state.random_chain_attack = Random.Range(1, 4);
    }

    public override void UpdateState(Boss1_State_Manager state)
    {
        if (state.chain_attack == state.random_chain_attack)
        {
            state.SwitchState(state.idle_state);
        }
    }

    public override void OnTriggerEnter(Boss1_State_Manager state)
    {

    }

    public override void OnTriggerExit(Boss1_State_Manager state)
    {
        state.SwitchState(state.idle_state);
    }

    public override void Timer_Inside_Trigger(Boss1_State_Manager state)
    {

    }
}
