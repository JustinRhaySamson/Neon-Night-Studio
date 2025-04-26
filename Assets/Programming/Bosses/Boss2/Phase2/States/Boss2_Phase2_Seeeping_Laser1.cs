using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Phase2_Seeeping_Laser1 : Boss2_Phase2_Base_State
{
    public override void EnterState(Boss2_Phase2_State_Machine state)
    {
        state.animator.SetBool("Sweeping_Laser1", true);
    }

    public override void UpdateState(Boss2_Phase2_State_Machine state)
    {

    }

    public override void Timer_Inside_Trigger(Boss2_Phase2_State_Machine state)
    {

    }
}
