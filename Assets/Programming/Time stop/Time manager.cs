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
    GameObject slider2;
    Slider slider_component;
    Slider slider_component2;
    float slider_time;
    float slider_time2;

    void Start()
    {
        slider = GameObject.Find("Time_shower");
        slider_component = slider.GetComponent<Slider>();
        slider2 = GameObject.Find("Time_Cooldown");
        slider_component2 = slider2.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time_Stopped)
        {
            slider_component.value = Time.time - slider_time;
        }
        if(!Time_Stopped && cooldown)
        {
            slider_component2.value = Time.time - slider_time2;
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
        if (!cooldown)
        {
            cooldown = true;
            Time_Stopped = true;
            slider_component.value = 0;
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
            StartCoroutine(ResetTime(time_amount));
            StartCoroutine(Cooldown_Timer());
        } 
    }

    IEnumerator ResetTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time_Stopped = false;
        slider_component2.value = 0;
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
    }

    IEnumerator Cooldown_Timer()
    {
        yield return new WaitForSeconds(6f);
        cooldown = false;
    }
}
