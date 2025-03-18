using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Time_Stop : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem[] particle_systems;

    GameObject Manager;
    Timemanager time_manager;
    ArrayExtensionMethods ae;
    Particle_Time_Stop script;
    public VFXYukiSlash tengu_slash;
    void Start()
    {
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        script = GetComponent<Particle_Time_Stop>();
        time_manager.particle_scripts = (Particle_Time_Stop[])ae.AddToArray(script, time_manager.particle_scripts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die_Particles()
    {
        time_manager.particle_scripts = (Particle_Time_Stop[])ae.Remove(script, time_manager.particle_scripts);
    }

    public void Time_Stop_Pause()
    {
        if (tengu_slash.vfx_activated)
        {
            foreach (ParticleSystem particleSystem in particle_systems)
            {
                particleSystem.Pause(true);
            }
        } 
    }

    public void Time_Stop_Restart()
    {
        if (tengu_slash.vfx_activated)
        {
            foreach (ParticleSystem particleSystem in particle_systems)
            {
                particleSystem.Play(true);
            }
        } 
    }
}
