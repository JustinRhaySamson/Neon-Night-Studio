using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Check : MonoBehaviour
{
    Health health;
    Boss_HP boss_HP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.gameObject;
            health = enemy.GetComponent<Health>();
            health.Get_Hit();
        }

        if (other.CompareTag("Boss"))
        {
            boss_HP = other.gameObject.GetComponent<Boss_HP>();
            boss_HP.Get_Hit();
        }
    }
}
