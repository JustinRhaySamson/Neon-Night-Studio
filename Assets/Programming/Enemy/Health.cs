using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int HP = 2;

    public void Get_Hit()
    {
        HP--;
        print(HP);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
