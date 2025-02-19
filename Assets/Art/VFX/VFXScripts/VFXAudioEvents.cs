using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAudioEvents : MonoBehaviour
{
    public GameObject VFXA1,VFXA2,VFXA3;

    public void ActivateA1()
    {
        VFXA1.SetActive(true);
        //Debug.Log("VFX activated");
    }

    public void ActivateA2()
    {
        VFXA2.SetActive(true);
        //Debug.Log("VFX activated");
    }

    public void ActivateA3()
    {
        VFXA3.SetActive(true);
        //Debug.Log("VFX activated");
    }

    public void DeactivateA1()
    {
        VFXA1.SetActive(false);
        //Debug.Log("VFX deactivated");
    }

    public void DeactivateA2()
    {
        VFXA2.SetActive(false);
        //Debug.Log("VFX deactivated");
    }

    public void DeactivateA3()
    {
        VFXA3.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
}
