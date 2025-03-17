using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_System : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] int enemies_to_kill;
    [SerializeField] int enemies_count = 0;
    [SerializeField] bool wave = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select_Enemies(GameObject[] enemies_sent, int kill_number)
    {
        enemies = enemies_sent;
        wave = true;
        enemies_to_kill = kill_number;
    }

    public void Enemy_Killed()
    {
        if (wave)
        {
            enemies_count++;
            if (enemies_count >= enemies_to_kill)
            {
                wave = false;
                enemies_count = 0;
                foreach (GameObject enemy in enemies)
                {
                    enemy.SetActive(true);
                }
            }
        }
    }
}
