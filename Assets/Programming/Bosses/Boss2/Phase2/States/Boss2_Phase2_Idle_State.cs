using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Phase2_Idle_State : Boss2_Phase2_Base_State
{
    public override void EnterState(Boss2_Phase2_State_Machine state)
    {
        state.animator.SetBool("Idle",true);
        state.animator.SetBool("Arm_Slam_M1", false);
        state.animator.SetBool("Arm_Slam_R1", false);
        state.animator.SetBool("Sweeping_Laser1", false);
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
            case 2:
                state.SwitchState(state.arm_Slam_R1);
                break;
        }

    }
}
