using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Script : MonoBehaviour
{
    Animator animator;
    float speed;
    Timemanager time_manager;
    ArrayExtensionMethods ae;
    Tornado_Script script;
    void Start()
    {
        script = GetComponent<Tornado_Script>();
        time_manager = GameObject.Find("Time manager").GetComponent<Timemanager>();
        ae = GameObject.Find("Time manager").GetComponent<ArrayExtensionMethods>();
        time_manager.tornado_scripts = (Tornado_Script[])ae.AddToArray(script, time_manager.tornado_scripts);
        animator = GetComponent<Animator>();
        speed = animator.GetFloat("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        time_manager.tornado_scripts = (Tornado_Script[])ae.Remove(script, time_manager.tornado_scripts);
        Object.Destroy(gameObject);
    }

    public void Time_Stop()
    {
        animator.SetFloat("Speed", 0);
    }

    public void Time_Reset()
    {
        animator.SetFloat("Speed", speed);
    }
}
