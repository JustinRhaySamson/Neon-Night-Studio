using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Counter : MonoBehaviour
{
    [SerializeField] int enemies_killed = 0;

    public int[] requirements;
    public GameObject[] doors;

    int requirements_met = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled()
    {
        enemies_killed++;

        if (enemies_killed == requirements[requirements_met])
        {
            Open_Doors();
            requirements_met++;
        }
    }

    void Open_Doors()
    {
        Destroy(doors[requirements_met]);
    }
}
