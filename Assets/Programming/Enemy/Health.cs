using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int HP = 2;
    public bool shooter = true;

    Time_Stop_Check_Melee time_stop_check_melee;
    Time_Stop_Check_Shooter time_stop_check_shooter;

    private void Start()
    {
        
    }

    public void Get_Hit()
    {
        HP--;
        if (HP <= 0)
        {
            if (!shooter)
            {
                time_stop_check_melee = GetComponent<Time_Stop_Check_Melee>();
                time_stop_check_melee.Die();
            }
            else if (shooter)
            {
                time_stop_check_shooter = GetComponent<Time_Stop_Check_Shooter>();
                time_stop_check_shooter.Die();
            }
            Destroy(gameObject);
        }
    }
}
