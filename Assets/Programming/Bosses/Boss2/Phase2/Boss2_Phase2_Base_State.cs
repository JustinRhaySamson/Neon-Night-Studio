using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss2_Phase2_Base_State
{
    public abstract void EnterState(Boss2_Phase2_State_Machine state);

    public abstract void UpdateState(Boss2_Phase2_State_Machine state);

    public abstract void Timer_Inside_Trigger(Boss2_Phase2_State_Machine state);
}

