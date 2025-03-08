using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Wall_State : Boss2_Base_State
{
    public override void EnterState(Boss2_State_Manager state)
    {
        state.animator.SetBool("Cyclonic_Slash", false);
        state.animator.SetBool("Storm", false);
        int number = 0;
        float distance = 1000;
        float prevDistance = 10000;
        for (int i = 0; i < state.arena_points.Length; i++)
        {
            distance = Vector3.Distance(state.transform.position, state.arena_points[i].transform.position);

            if (distance < prevDistance)
            {
                prevDistance = distance;
                number = i;
            }
        }

        state.point_to_look = state.arena_points[number].transform;
        state.Look_At_Wall();
    }

    public override void UpdateState(Boss2_State_Manager state)
    {
        if (state.transform.position.x <= state.point_to_look.position.x + 1
            && state.transform.position.x >= state.point_to_look.position.x - 1
            && state.transform.position.z <= state.point_to_look.position.z + 1
            && state.transform.position.z >= state.point_to_look.position.z - 1)
        {
            state.SwitchState(state.shoulder_bash);
        }
    }

    public override void OnTriggerEnter(Boss2_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss2_State_Manager state)
    {

    }

    public override void OnCollisionEnter(Boss2_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss2_State_Manager state)
    {

    }
}
