using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Cyclonic_Slah : Boss2_Base_State
{
    public override void EnterState(Boss2_State_Manager state)
    {
        state.animator.SetBool("Cyclonic_Slash", true);
    }

    public override void UpdateState(Boss2_State_Manager state)
    {

    }

    public override void OnTriggerEnter(Boss2_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss2_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss2_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss2_State_Manager state)
    {

    }
}
