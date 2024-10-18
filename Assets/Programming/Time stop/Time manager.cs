using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour
{
    public float time_amount = 0;
    public bool Time_Stopped = false;

    public Time_Stop_Check_Shooter[] enemies_shooter;
    public Time_Stop_Check_Melee[] enemies_melee;
    public Basic_Bullet[] bullets;

    bool LB_Press = false;
    bool RB_Press = false;

    void Start()
    {
        //print(enemies_shooter.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Time_Stopped = true;

        if (Time_Stopped)
        {
            for(int i = 0; i < enemies_shooter.Length; i++)
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
        }
        StartCoroutine(ResetTime(time_amount));
    }

    IEnumerator ResetTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time_Stopped = false;
        for (int i = 0; i < enemies_shooter.Length; i++)
        {
            enemies_shooter[i].RestartEnemy();
        }
        for (int i = 0; i < enemies_shooter.Length; i++)
        {
            enemies_melee[i].RestartEnemy();
        }
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].RestartBullet();
        }
    }
}
