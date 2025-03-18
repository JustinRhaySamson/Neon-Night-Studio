using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXOniSlash : MonoBehaviour
{
    public GameObject VFXA1, VFXA2, VFXA3, VFXA4;

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
        //Phase 2 Claw Slash
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
        //Phase 2 Claw Slash
        VFXA3.SetActive(true);
        //Debug.Log("VFX activated");
    }
    
    public void DeactivateA3()
    {
        VFXA3.SetActive(false);
        //Debug.Log("VFX deactivated");
    }
    
        public void ActivateA4()
        {
            //Phase 2 Oni Aura
            VFXA4.SetActive(true);
            //Debug.Log("VFX activated");
        }
        
        public void DeactivateA4()
        {
            VFXA4.SetActive(false);
            //Debug.Log("VFX deactivated");
        }
}
