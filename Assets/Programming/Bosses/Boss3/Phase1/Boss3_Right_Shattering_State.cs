using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_Right_Shattering_State : Boss3_Base_State
{
    public override void EnterState(Boss3_State_Manager state)
    {
        state.animator.SetBool("Right_Shattering", true);
    }

    public override void UpdateState(Boss3_State_Manager state)
    {

    }

    public override void OnTriggerEnter(Boss3_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss3_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss3_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss3_State_Manager state)
    {

    }
}
