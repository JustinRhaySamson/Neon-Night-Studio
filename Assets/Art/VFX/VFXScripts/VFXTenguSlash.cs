using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXYukiSlash : MonoBehaviour
{
    public GameObject VFXA1, VFXA2, VFXA3;
    public bool vfx_activated = false;

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
    
    public void ActivateA2()
    {
        vfx_activated = true;
        VFXA2.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA2()
    {
        VFXA2.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
    
    public void ActivateA3()
    {
        VFXA3.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA3()
    {
        vfx_activated = false;
        VFXA3.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
}
