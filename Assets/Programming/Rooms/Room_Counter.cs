using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Counter : MonoBehaviour
{
    [SerializeField] int enemies_killed = 0;
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
    }
}
