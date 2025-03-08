using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss2_Base_State
{
    public abstract void EnterState(Boss2_State_Manager state);

    public abstract void UpdateState(Boss2_State_Manager state);

    public abstract void OnTriggerEnter(Boss2_State_Manager state);

    public abstract void OnTriggerExit(Boss2_State_Manager state);

    public abstract void OnCollisionEnter(Boss2_State_Manager state);

    public abstract void Timer_Inside_Trigger(Boss2_State_Manager state);
}
