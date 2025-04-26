using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Phase2_Idle_Left_State : Boss2_Phase2_Base_State
{
    public override void EnterState(Boss2_Phase2_State_Machine state)
    {
        state.max_Random = 2;
        state.animator.SetBool("Idle_Left", true);
        
    }

    public override void UpdateState(Boss2_Phase2_State_Machine state)
    {

    }

    public override void Timer_Inside_Trigger(Boss2_Phase2_State_Machine state)
    {
        switch (state.random_number)
        {
            case 0:
                state.SwitchState(state.sweeping_laser1);
                break;
            case 1:
                state.SwitchState(state.arm_Slam_M1);
                break;
        }

    }
}
