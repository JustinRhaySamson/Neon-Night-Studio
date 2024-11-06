using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Take_Knockback : MonoBehaviour
{
    bool time_stopped = false;
    bool force_stored = false;

    Rigidbody rb;
    Vector3 knockback_direction;
    float knockback_velocity;

    GameObject manager;
    Timemanager timemanager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("Time manager");
        timemanager = manager.GetComponent<Timemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        time_stopped = timemanager.Time_Stopped;
        if (!time_stopped && force_stored)
        {
            TakeKnockback(knockback_direction, knockback_velocity);
            force_stored = false;
        }

    }

    public void TakeKnockback(Vector3 direction, float force)
    {
        print(time_stopped + " time stopped");
        if (!time_stopped)
        {
            knockback_direction = direction;
            knockback_velocity = force;
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
        else if (time_stopped)
        {
            force_stored = true;
            knockback_direction = direction;
            knockback_velocity = force;
            print(force_stored + " Force stored");
        }
    }
}
