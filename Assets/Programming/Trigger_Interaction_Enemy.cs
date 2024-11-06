using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Trigger_Interaction_Enemy: MonoBehaviour
{
    public UnityEvent trigger_entered;
    public UnityEvent trigger_exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger_entered.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger_exited.Invoke();
        }
    }
}
