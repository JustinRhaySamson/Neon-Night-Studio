using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Time_Stop_Check_Melee : MonoBehaviour
{
    GameObject Manager;
    Timemanager time_manager;
    Time_Stop_Check_Melee time_stop_check_melee;
    ArrayExtensionMethods ae;
    bool weapon_state;

    public Look_At look_at;
    public Animator animator;
    public NavMeshAgent nav_Agent;
    public SphereCollider sphere_Collider;
    public CapsuleCollider weapon;
    void Start()
    {
        time_stop_check_melee = GetComponent<Time_Stop_Check_Melee>();
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        time_manager.enemies_melee = (Time_Stop_Check_Melee[])ae.AddToArray(time_stop_check_melee, time_manager.enemies_melee);
        if (time_manager.Time_Stopped)
        {
            StopEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time_manager.Time_Stopped)
        {
            nav_Agent.enabled = false;
        }
    }

    public void StopEnemy()
    {
        weapon_state = weapon.enabled;
        look_at.enabled = false;
        nav_Agent.enabled = false;
        animator.SetFloat("Animation_Speed", 0);
        sphere_Collider.enabled = false;
        weapon.enabled = false;
    }

    public void RestartEnemy()
    {
        //look_at.enabled = true;
        nav_Agent.enabled = true;
        animator.SetFloat("Animation_Speed", 1);
        sphere_Collider.enabled = true;
        weapon.enabled = weapon_state;
    }

    public void Die()
    {
        time_manager.enemies_melee = (Time_Stop_Check_Melee[])ae.Remove(time_stop_check_melee, time_manager.enemies_melee);
    }
}
