using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_State_Manager : MonoBehaviour
{
    Boss1_Base_State currentState;

    public Boss1_State_Idle idle_state = new Boss1_State_Idle();
    public Boss1_State_Strong_Right strong_Right = new Boss1_State_Strong_Right();
    public Boss1_State_Death_Dive death_Dive = new Boss1_State_Death_Dive();
    public Boos1_State_Rolling_Thunder rolling_Thunder = new Boos1_State_Rolling_Thunder();

    public Animator animator;
    public int random_number = 0;
    public int chain_attack = 1;
    public int random_chain_attack = 1;
    public bool inside_trigger = false;
    // Start is called before the first frame update
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

    public void SwitchState(Boss1_Base_State state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            inside_trigger = true;
            random_number = Random.Range(0, 2);
            currentState.OnTriggerEnter(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            inside_trigger = false;
            currentState.OnTriggerExit(this);
        }
    }

    public void Set_Anim_Speed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void Chain_Attack_Up()
    {
        chain_attack++;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
            print("The one bool in the state machine is: " + inside_trigger);
            random_number = Random.Range(0, 2);
            currentState.Timer_Inside_Trigger(this);
        }
    }

    public void Back_To_Idle()
    {
        currentState = idle_state;
        currentState.EnterState(this);
    }
}
