using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Time_Stop_Check_Shooter: MonoBehaviour
{
    GameObject Manager;
    Timemanager time_manager;

    public Look_At look_at;
    public Shoot_bullet shoot_Bullet;
    public NavMeshAgent nav_Agent;
    public SphereCollider sphere_Collider;
    public SphereCollider sphere_Collider2;

    bool restart;
    void Start()
    {
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartEnemy()
    {
        if (time_manager.Time_Stopped)
        {
            look_at.enabled = false;
            shoot_Bullet.not_stopped = false;
            nav_Agent.enabled = false;
            sphere_Collider.enabled = false;
            sphere_Collider2.enabled = false;
        }
        else if (!time_manager.Time_Stopped)
        {
            look_at.enabled = true;
            nav_Agent.enabled = true;
            sphere_Collider2.enabled = true;
            sphere_Collider.enabled = true;
            shoot_Bullet.not_stopped = true;

            //shoot_Bullet.restartShooting = true;
            //shoot_Bullet.RestartShooting();
        }
    }
}
