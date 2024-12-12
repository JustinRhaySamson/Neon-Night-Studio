using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAudioEvents : MonoBehaviour
{
    public GameObject VFXA1,VFXA2,VFXA3;

    void ActivateA1()
    {
        VFXA1.SetActive(true);
        Debug.Log("VFX activated");
    }
    
    void ActivateA2()
    {
        VFXA2.SetActive(true);
        Debug.Log("VFX activated");
    }
    
    void ActivateA3()
    {
        VFXA3.SetActive(true);
        Debug.Log("VFX activated");
    }

    void DeactivateA1()
    {
        VFXA1.SetActive(false);
        Debug.Log("VFX deactivated");
    }
    
    void DeactivateA2()
    {
        VFXA2.SetActive(false);
        Debug.Log("VFX deactivated");
    }
    
    void DeactivateA3()
    {
        VFXA3.SetActive(false);
        Debug.Log("VFX deactivated");
    }
}
