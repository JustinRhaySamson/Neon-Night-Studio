using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXYukiSlash : MonoBehaviour
{
    public GameObject VFXA1, VFXA2, VFXA3, VFXA4, VFXA5, VFXA6;
    public bool vfx_activated = false;

    public void ActivateA1()
    {
        //Slash
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
        //Attack indicator (so probably no sfx)
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
        //Attack indicator (so probably no sfx)
        VFXA3.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA3()
    {
        vfx_activated = false;
        VFXA3.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
    
    public void ActivateA4()
    {
        VFXA4.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA4()
    {
        VFXA4.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
    
    public void ActivateA5()
    {
        VFXA5.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA5()
    {
        VFXA5.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
    
    public void ActivateA6()
    {
        VFXA6.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA6()
    {
        VFXA6.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
}
