using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Counter : MonoBehaviour
{
    [SerializeField] int enemies_killed = 0;

    public int[] requirements;
    public GameObject[] doors;

    [SerializeField] int requirements_met = 0;
    int requirements_done = 0;

    Player_Store_Data player_store_data;
    void Start()
    {
        player_store_data = GameObject.Find("Player").GetComponent<Player_Store_Data>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies_killed >= requirements[requirements_met])
        {
            player_store_data.enemies_killed = requirements[requirements_met];
            //print(player_store_data.enemies_killed);
            Open_Doors();
            requirements_met++;
            
        }
    }

    public void EnemyKilled()
    {
        enemies_killed++;
    }

    void Open_Doors()
    {
        doors[requirements_met].SetActive(false);
        if(requirements_met >= 1)
        {
            doors[requirements_met - 1].SetActive(true);
        }
    }
    
    public void Set_Enemies_Killed(int killed)
    {
        enemies_killed = killed;
    }

}
