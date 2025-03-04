using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Lightning_Script : MonoBehaviour
{
    public VisualEffect[] VFXgraphs;
    public ParticleSystem[] particle_systems;

    Animator anim;
    public bool idling = false;

    GameObject Manager;
    Timemanager time_manager;
    ArrayExtensionMethods ae;
    Lightning_Script lightning_script;
    void Start()
    {
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        lightning_script = GetComponent<Lightning_Script>();
        time_manager.lightnings = (Lightning_Script[])ae.AddToArray(lightning_script, time_manager.lightnings);
        anim = GetComponent<Animator>();
        if (!idling)
        {
            anim.SetBool("Idle", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        time_manager.lightnings = (Lightning_Script[])ae.Remove(lightning_script, time_manager.lightnings);
        Object.Destroy(gameObject);
    }

    public void Time_Stop_Pause()
    {
        foreach(VisualEffect effect in VFXgraphs)
        {
            effect.pause = true;
        }
        foreach(ParticleSystem particleSystem in particle_systems)
        {
            particleSystem.Pause(true);
        }
        anim.SetFloat("Speed", 0);
    }

    public void Time_Stop_Restart()
    {
        foreach (VisualEffect effect in VFXgraphs)
        {
            effect.pause = false;
        }
        foreach (ParticleSystem particleSystem in particle_systems)
        {
            particleSystem.Play(true);
        }
        anim.SetFloat("Speed", 1);
    }
}
