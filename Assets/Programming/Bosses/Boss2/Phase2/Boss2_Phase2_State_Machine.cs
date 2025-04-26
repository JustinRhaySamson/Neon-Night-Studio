using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Phase2_State_Machine : MonoBehaviour
{
    Boss2_Phase2_Base_State currentState;
    
    public Boss2_Phase2_Idle_State idle_state = new Boss2_Phase2_Idle_State();
    public Boss2_Phase2_Idle_Right_State idle_Right_State = new Boss2_Phase2_Idle_Right_State();
    public Boss2_Phase2_Idle_Left_State idle_Left_State = new Boss2_Phase2_Idle_Left_State();
    public Boss2_Phase2_Seeeping_Laser1 sweeping_laser1 = new Boss2_Phase2_Seeeping_Laser1();
    public Boss2_Phase2_Arm_Slam_R1 arm_Slam_R1 = new Boss2_Phase2_Arm_Slam_R1();
    public Boss2_Phase2_Arm_Slam_M1 arm_Slam_M1 = new Boss2_Phase2_Arm_Slam_M1();

    public Animator animator;
    public int random_number = 0;
    [HideInInspector] public int max_Random = 3;

    public bool broken_RHand;
    public bool broken_LHand;
    void Start()
    {
        currentState = idle_state;
        currentState.EnterState(this);
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Boss2_Phase2_Base_State state)
    {
        currentState = state;
        print("The current state is " + currentState.ToString());
        state.EnterState(this);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.1f);
            //print("The one bool in the state machine is: " + inside_trigger);
            random_number = Random.Range(0, max_Random);
            //print("The random number is " + random_number);
            currentState.Timer_Inside_Trigger(this);
        }
    }

    public void Back_To_Idle()
    {
        currentState = idle_state;
        currentState.EnterState(this);
    }

    public void RHand_Break()
    {
        broken_RHand = true;
        currentState = idle_Right_State;
        currentState.EnterState(this);
    }

    public void LHand_Break()
    {
        broken_LHand = true;
        currentState = idle_Left_State;
        currentState.EnterState(this);
    }
}
