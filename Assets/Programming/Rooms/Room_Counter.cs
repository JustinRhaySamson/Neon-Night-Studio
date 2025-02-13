using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Counter : MonoBehaviour
{
    [SerializeField] int enemies_killed = 0;

    public int[] requirements;
    public GameObject[] doors;

    [SerializeField] int requirements_met = 0;

    Player_Store_Data player_store_data;
    void Start()
    {
        player_store_data = GameObject.Find("Player").GetComponent<Player_Store_Data>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled()
    {
        enemies_killed++;

        if (enemies_killed >= requirements[requirements_met])
        {
            player_store_data.enemies_killed = requirements[requirements_met];
            Open_Doors();
            requirements_met++;
        }
    }

    void Open_Doors()
    {
        Destroy(doors[requirements_met]);
    }
    
    public void Set_Enemies_Killed(int killed)
    {
        enemies_killed = killed;
    }
}
