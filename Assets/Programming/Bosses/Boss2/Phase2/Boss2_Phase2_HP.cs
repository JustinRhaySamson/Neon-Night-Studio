using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Boss2_Phase2_HP : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    public Sprite heathbar_1;
    public Animator animator;
    public UnityEvent die;

    GameObject slider;
    Slider slider_component;
    Animator slider_animator;
    GameObject time_manager;
    Timemanager time_Script;
    Image healthbar_image;
    float previous_speed;
    void Start()
    {
        slider = GameObject.Find("Boss_HP_Slider");
        slider_component = slider.GetComponent<Slider>();
        slider_animator = slider.GetComponent<Animator>();
        time_manager = GameObject.Find("Time manager");
        time_Script = time_manager.GetComponent<Timemanager>();
        healthbar_image = GameObject.Find("Boss_Health_Image").GetComponent<Image>();
        time_Script.boss2_2_Scene = true;
        time_Script.boss2_Phase2_HP = this;
        Start_Fight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_Fight()
    {
        slider_component.maxValue = MaxHP;
        slider_component.value = HP;
        slider_animator.SetBool("Active", true);
        healthbar_image.sprite = heathbar_1;
    }

    public void Got_Hit()
    {
        HP--;
        slider_component.value = HP;
        if (HP <= 0)
        {
            //time_Script.boss2_2_Scene = false;
            slider_animator.SetBool("Active", false);
            die.Invoke();
            animator.SetBool("Dead", true);
            //Destroy(gameObject);
        }
    }

    public void Stop_Time()
    {
        previous_speed = animator.GetFloat("Speed");
        animator.SetFloat("Speed", 0);
    }

    public void Reset_Time()
    {
        animator.SetFloat("Speed", previous_speed);
    }
}
