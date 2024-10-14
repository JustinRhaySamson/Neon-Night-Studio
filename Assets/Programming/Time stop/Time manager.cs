using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour
{
    public bool Time_Stopped = false;

    public Time_Stop_Check_Shooter[] enemies_shooter;
    public Time_Stop_Check_Melee[] enemies_melee;
    public Basic_Bullet[] bullets;

    void Start()
    {
        //print(enemies_shooter.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTime()
    {
        Time_Stopped = !Time_Stopped;

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

        if (!Time_Stopped)
        {
            for (int i = 0; i < enemies_shooter.Length; i++)
            {
                print("a shooter");
                enemies_shooter[i].RestartEnemy();
            }
            for (int i = 0; i < enemies_shooter.Length; i++)
            {
                enemies_melee[i].RestartEnemy();
            }
            for (int i = 0; i < bullets.Length; i++)
            {
                print("a bullet");
                bullets[i].RestartBullet();
            }
        }
    }
}
