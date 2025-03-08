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
    Boss2_State_Manager state_manager2;
    bool life_regen = false;

    bool phase1 = true;

    [SerializeField] bool boss1 = false;
    [SerializeField] bool boss2 = false;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Boss_HP_Slider");
        slider_component = slider.GetComponent<Slider>();
        slider_animator = slider.GetComponent <Animator>();
        time_manager = GameObject.Find("Time manager");
        time_Script = time_manager.GetComponent<Timemanager>();
        if (boss1)
        {
            time_Script.Activate_Boss1(gameObject);
        }
        else if (boss2)
        {

        }
        animator = gameObject.GetComponent<Animator>();
        if (boss1)
        {
            state_manager = gameObject.GetComponent<Boss1_State_Manager>();
        }
        else if (boss2)
        {
            state_manager2 = gameObject.GetComponent<Boss2_State_Manager>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (life_regen)
        {
            slider_component.value = Mathf.Lerp(slider_component.value, maxHP + 30, .02f);
            if(slider_component.value >= maxHP)
            {
                life_regen = false;
            }
        }
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
        if (boss1)
        {
            if (HP <= 0 && phase1 && !life_regen)
            {
                state_manager.SwitchState(state_manager.phase2_idle_state);
                HP = maxHP;
                life_regen = true;
                animator.SetBool("Phase2", true);
                phase1 = false;
            }
            else if (HP <= 0 && !phase1 && !life_regen)
            {
                time_Script.boss1_scene = false;
                slider_animator.SetBool("Active", false);
                Destroy(gameObject);
            }
        }
        
        else if (boss2)
        {
            if (HP <= 0 && phase1 && !life_regen)
            {
                //time_Script.boss1_scene = false;
                slider_animator.SetBool("Active", false);
                Destroy(gameObject);
            }
        }
    }
}
