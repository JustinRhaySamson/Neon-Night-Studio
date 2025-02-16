using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss1_Base_State
{
    public abstract void EnterState(Boss1_State_Manager state);

    public abstract void UpdateState(Boss1_State_Manager state);

    public abstract void OnTriggerEnter(Boss1_State_Manager state);

    public abstract void OnTriggerExit(Boss1_State_Manager state);

    public abstract void Timer_Inside_Trigger(Boss1_State_Manager state);
}
