using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Check : MonoBehaviour
{
    Health health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("LMAO GOTTEM");
            GameObject enemy = other.gameObject;
            health = enemy.GetComponent<Health>();
            health.Get_Hit();
        }
    }
}
