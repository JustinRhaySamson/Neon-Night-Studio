using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss3_Base_State
{
    public abstract void EnterState(Boss3_State_Manager state);

    public abstract void UpdateState(Boss3_State_Manager state);

    public abstract void OnTriggerEnter(Boss3_State_Manager state);

    public abstract void OnTriggerExit(Boss3_State_Manager state);

    public abstract void OnCollisionEnter(Boss3_State_Manager state);

    public abstract void Timer_Inside_Trigger(Boss3_State_Manager state);
}
