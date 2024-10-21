using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    public float force = 10;
    Enemy_Take_Knockback take_Knockback;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            take_Knockback = other.GetComponent<Enemy_Take_Knockback>();
            take_Knockback.TakeKnockback(transform.forward, force);
        }
    }
}
