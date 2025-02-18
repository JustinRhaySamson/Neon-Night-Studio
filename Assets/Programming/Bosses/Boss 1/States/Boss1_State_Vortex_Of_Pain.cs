using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Vortex_Of_Pain : Boss1_Base_State
{
    public override void EnterState(Boss1_State_Manager state)
    {
        state.animator.SetBool("Vortex_Of_Pain", true);
        state.dash_VFX.SetActive(false);
        Rigidbody rb = state.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        state.dashing_to_center = false;
        state.attacks_made = 0;
    }

    public override void UpdateState(Boss1_State_Manager state)
    {
        
    }

    public override void OnTriggerEnter(Boss1_State_Manager state)
    {


    }

    public override void OnTriggerExit(Boss1_State_Manager state)
    {

    }

    public override void Timer_Inside_Trigger(Boss1_State_Manager state)
    {

    }
}
