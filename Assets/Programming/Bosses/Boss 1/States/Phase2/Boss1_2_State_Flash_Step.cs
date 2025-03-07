using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_2_State_Flash_Step : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Flash_Step", true);
        state.attacks_made++;
    }

    public override void UpdateState(Boss1_State_Manager state)
    {

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
