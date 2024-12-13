using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon_Interaction : MonoBehaviour
{
    public UnityEvent trigger_entered;
    public UnityEvent trigger_exited;

    GameObject player;
    Player_Health playerHealth;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<Player_Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger_entered.Invoke();
            playerHealth.Get_Hit();
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
