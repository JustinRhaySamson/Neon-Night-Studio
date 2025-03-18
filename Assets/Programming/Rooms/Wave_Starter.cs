using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Starter : MonoBehaviour
{
    public GameObject[] enemies_to_spawn;
    public int enemies_to_kill;
    Wave_System wave_system;

    bool stay = false;
    // Start is called before the first frame update
    void Start()
    {
        wave_system = GameObject.Find("Wave Manager").GetComponent<Wave_System>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            wave_system.Select_Enemies(enemies_to_spawn,enemies_to_kill);
        }
    }
}
