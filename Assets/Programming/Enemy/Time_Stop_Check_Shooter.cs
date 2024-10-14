using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Time_Stop_Check_Shooter: MonoBehaviour
{
    GameObject Manager;
    Timemanager time_manager;
    Time_Stop_Check_Shooter time_stop_check_shooter;
    ArrayExtensionMethods ae;

    public Look_At look_at;
    public Shoot_bullet shoot_Bullet;
    public GameObject bullet_shooter;
    public NavMeshAgent nav_Agent;
    public SphereCollider sphere_Collider;
    public SphereCollider sphere_Collider2;

    bool restart;
    void Start()
    {
        time_stop_check_shooter = GetComponent<Time_Stop_Check_Shooter>();
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        time_manager.enemies_shooter = (Time_Stop_Check_Shooter[])ae.AddToArray(time_stop_check_shooter, time_manager.enemies_shooter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopEnemy()
    {
        look_at.enabled = false;
        //shoot_Bullet.StopShooting();
        bullet_shooter.SetActive(false);
        nav_Agent.enabled = false;
        sphere_Collider.enabled = false;
        sphere_Collider2.enabled = false;
    }

    public void RestartEnemy()
    {
        look_at.enabled = true;
        nav_Agent.enabled = true;
        sphere_Collider2.enabled = true;
        sphere_Collider.enabled = true;
        bullet_shooter.SetActive(true);
        shoot_Bullet.StartShooting();
    }

    public void Die()
    {
        time_manager.enemies_shooter = (Time_Stop_Check_Shooter[])ae.Remove(time_stop_check_shooter, time_manager.enemies_shooter);
    }
}
