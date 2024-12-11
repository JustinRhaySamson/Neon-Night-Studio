using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timemanager : MonoBehaviour
{
    public float time_amount = 0;
    public bool Time_Stopped = false;
    public bool cooldown = false;

    public Time_Stop_Check_Shooter[] enemies_shooter;
    public Time_Stop_Check_Melee[] enemies_melee;
    public Basic_Bullet[] bullets;

    bool LB_Press = false;
    bool RB_Press = false;

    GameObject slider;
    Slider slider_component;
    float slider_time;
    float slider_time2;

    GameObject door;
    Animator door_animator;
    GameObject door_stopper;

    void Start()
    {
        slider = GameObject.Find("Slider_new");
        slider_component = slider.GetComponent<Slider>();
        door = GameObject.Find("TimeStop_Door");
        door_animator = door.GetComponent<Animator>();
        door_stopper = GameObject.Find("Door_Stopper");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time_Stopped)
        {
            slider_component.value = 2.9f - (Time.time - slider_time);
        }
        if(!Time_Stopped && cooldown)
        {
            slider_component.value = Time.time - slider_time2;
        }
    }

    public void LB_Check()
    {
        LB_Press = true;
        Button_Combo();
        StartCoroutine(LB_Time());
    }

    IEnumerator LB_Time()
    {
        yield return new WaitForSeconds(.1f);
        LB_Press=false;
    }

    public void RB_Check()
    {
        RB_Press = true;
        Button_Combo();
        StartCoroutine(RB_Time());
    }

    IEnumerator RB_Time()
    {
        yield return new WaitForSeconds(.1f);
        RB_Press = false;
    }

    void Button_Combo()
    {
        if (LB_Press && RB_Press)
        {
            ChangeTime();
        }
    }

    public void ChangeTime()
    {
        if (!cooldown && slider_component.value == slider_component.maxValue)
        {
            cooldown = true;
            Time_Stopped = true;
            slider_component.maxValue = 2.9f;
            slider_component.value = 2.9f;
            slider_time = Time.time;
            for (int i = 0; i < enemies_shooter.Length; i++)
            {
                enemies_shooter[i].StopEnemy();
            }
            for (int i = 0; i < enemies_melee.Length; i++)
            {
                enemies_melee[i].StopEnemy();
            }
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].StopBullet();
            }
            if (door_animator != null)
            {
                door_animator.SetFloat("Speed", 0);
                door_stopper.SetActive(false);
            }
            StartCoroutine(ResetTime(time_amount));
            StartCoroutine(Cooldown_Timer());
        } 
    }

    IEnumerator ResetTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time_Stopped = false;
        slider_component.maxValue = 4;
        slider_time2 = Time.time;
        for (int i = 0; i < enemies_shooter.Length; i++)
        {
            enemies_shooter[i].RestartEnemy();
        }
        for (int i = 0; i < enemies_melee.Length; i++)
        {
            enemies_melee[i].RestartEnemy();
        }
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].RestartBullet();
        }
        if (door_animator != null)
        {
            door_animator.SetFloat("Speed", 1);
            door_stopper.SetActive(true);
        }
    }

    IEnumerator Cooldown_Timer()
    {
        yield return new WaitForSeconds(7.1f);
        cooldown = false;
    }
}
