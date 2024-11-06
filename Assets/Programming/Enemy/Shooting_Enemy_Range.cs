using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Shooting_Enemy_Range : MonoBehaviour
{
    public UnityEvent trigger_entered;
    public UnityEvent trigger_exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            trigger_entered.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            trigger_exited.Invoke();
        }
    }
}
