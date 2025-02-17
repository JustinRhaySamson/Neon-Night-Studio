using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos1_State_Rolling_Thunder : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Rolling_Thunder", true);
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
