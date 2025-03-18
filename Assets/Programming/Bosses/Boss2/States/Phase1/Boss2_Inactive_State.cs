using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Inactive_State : Boss2_Base_State
{
    public override void EnterState(Boss2_State_Manager state)
    {
        state.animator.SetBool("Running", false);
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
