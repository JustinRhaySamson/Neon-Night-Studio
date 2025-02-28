using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEnemySlash : MonoBehaviour
{
    public GameObject VFXA1;

    public void ActivateA1()
    {
        VFXA1.SetActive(true);
        //Debug.Log("VFX activated");
    }

    public void DeactivateA1()
    {
        VFXA1.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
}
