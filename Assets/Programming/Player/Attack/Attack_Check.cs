using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Check : MonoBehaviour
{
    Health health;
    Boss_HP boss_HP;
    Hand_HP hand_HP;

    GameObject slider;
    Slider slider_component;

    GameObject time_manager_object;
    Timemanager time_manager_script;

    public GameObject player;
    Player_Health player_health;

    private void Start()
    {
        //slider = GameObject.Find("Slider_new");
        //slider_component = slider.GetComponent<Slider>();
        time_manager_object = GameObject.Find("Time manager");
        time_manager_script = time_manager_object.GetComponent<Timemanager>();
        player_health = player.GetComponent<Player_Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.gameObject;
            health = enemy.GetComponent<Health>();
            health.Get_Hit();
            time_manager_script.refill_timer++;
            player_health.refill_timer_health++;
        }

        else if (!other.isTrigger && other.CompareTag("Boss"))
        {
            boss_HP = other.gameObject.GetComponent<Boss_HP>();
            boss_HP.Get_Hit();
            time_manager_script.refill_timer++;
            player_health.refill_timer_health++;
        }

        else if (other.CompareTag("Hand"))
        {
            hand_HP = other.gameObject.GetComponent<Hand_HP>();
            hand_HP.Get_Hit();
            time_manager_script.refill_timer++;
            player_health.refill_timer_health++;
        }
    }
}
