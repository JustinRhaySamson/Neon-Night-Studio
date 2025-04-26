using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Phase2_Laser_SPread_State : Boss2_Phase2_Base_State
{
    public override void EnterState(Boss2_Phase2_State_Machine state)
    {
        state.animator.SetBool("Laser_Spread", true);
    }

    public override void UpdateState(Boss2_Phase2_State_Machine state)
    {

    }

    public override void Timer_Inside_Trigger(Boss2_Phase2_State_Machine state)
    {

    }
}
