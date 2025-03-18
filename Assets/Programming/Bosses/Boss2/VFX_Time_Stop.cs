using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFX_Time_Stop : MonoBehaviour
{
    public VisualEffect[] VFXgraphs;
    GameObject Manager;
    Timemanager time_manager;
    ArrayExtensionMethods ae;
    VFX_Time_Stop VFX_time_stop;
    void Start()
    {
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        VFX_time_stop = GetComponent<VFX_Time_Stop>();
        time_manager.vfx_scripts = (VFX_Time_Stop[])ae.AddToArray(VFX_time_stop, time_manager.vfx_scripts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Time_Stop_Pause()
    {
        foreach (VisualEffect effect in VFXgraphs)
        {
            effect.pause = true;
        }
    }

    public void Time_Stop_Restart()
    {
        foreach (VisualEffect effect in VFXgraphs)
        {
            effect.pause = false;
        }
    }

    public void Die()
    {
        time_manager.vfx_scripts = (VFX_Time_Stop[])ae.Remove(VFX_time_stop, time_manager.vfx_scripts);
        //Object.Destroy(gameObject);
    }
}
