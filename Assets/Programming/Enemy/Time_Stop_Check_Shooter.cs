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
    bool bullet_shooter_state;
    bool navmesh_state;
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
        navmesh_state = nav_Agent.enabled;
        nav_Agent.enabled = false;
        //sphere_Collider.enabled = false;
        //sphere_Collider2.enabled = false;
    }

    public void RestartEnemy()
    {
        look_at.enabled = true;
        nav_Agent.enabled = navmesh_state;
        //sphere_Collider2.enabled = true;
        //sphere_Collider.enabled = true;
        bullet_shooter.SetActive(bullet_shooter_state);
        if (bullet_shooter_state)
        {
            shoot_Bullet.StartShooting();
        }
    }

    public void Die()
    {
        time_manager.enemies_shooter = (Time_Stop_Check_Shooter[])ae.Remove(time_stop_check_shooter, time_manager.enemies_shooter);
    }

    public void Enter_Shooting_Sphere()
    {
        if (!time_manager.Time_Stopped)
        {
            bullet_shooter.SetActive(true);
            shoot_Bullet.StartShooting();
        }
        bullet_shooter_state = true;
    }

    public void Exit_Shooting_Sphere()
    {
        if (!time_manager.Time_Stopped)
        {
            bullet_shooter.SetActive(false);
        }
        bullet_shooter_state = false;
    }

    public void Enter_Movement_Sphere()
    {
        if (!time_manager.Time_Stopped)
        {
            nav_Agent.enabled = false;
        }
        navmesh_state = false;
    }

    public void Exit_Movement_Sphere()
    {
        if (!time_manager.Time_Stopped)
        {
            nav_Agent.enabled = true;
        }
        navmesh_state = true;
    }
}
