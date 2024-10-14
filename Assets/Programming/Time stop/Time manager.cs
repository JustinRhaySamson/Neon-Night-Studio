using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour
{
    public bool Time_Stopped = false;

    public Time_Stop_Check_Shooter[] enemies_shooter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTime()
    {
        Time_Stopped = !Time_Stopped;
    }
}
