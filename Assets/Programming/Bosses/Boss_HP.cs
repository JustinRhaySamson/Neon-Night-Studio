using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HP : MonoBehaviour
{
    public int HP;
    public int maxHP;
    GameObject slider;
    Slider slider_component;
    Animator slider_animator;
    GameObject time_manager;
    Timemanager time_Script;
    Animator animator;
    Boss1_State_Manager state_manager;

    bool phase1 = true;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Boss_HP_Slider");
        slider_component = slider.GetComponent<Slider>();
        slider_animator = slider.GetComponent <Animator>();
        time_manager = GameObject.Find("Time manager");
        time_Script = time_manager.GetComponent<Timemanager>();
        time_Script.Activate_Boss1(gameObject);
        animator = gameObject.GetComponent<Animator>();
        state_manager = gameObject.GetComponent<Boss1_State_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_Fight()
    {
        slider_component.maxValue = maxHP;
        slider_component.value = HP;
        slider_animator.SetBool("Active", true);
    }

    public void Get_Hit()
    {
        HP--;
        slider_component.value = HP;
        if (HP <= 0 && phase1)
        {
            state_manager.SwitchState(state_manager.phase2_idle_state);
            HP = maxHP;
            slider_component.value = HP;
            animator.SetBool("Phase2", true);
            phase1 = false;
        }
        else if (HP <= 0 && !phase1)
        {
            time_Script.boss1_scene = false;
            slider_animator.SetBool("Active", false);
            Destroy(gameObject);
        }
    }
}
