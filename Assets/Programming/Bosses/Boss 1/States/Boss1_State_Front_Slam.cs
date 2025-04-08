using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Front_Slam : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Front_Slam", true);
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
