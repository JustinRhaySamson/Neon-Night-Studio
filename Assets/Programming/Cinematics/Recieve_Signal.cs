using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Recieve_Signal : MonoBehaviour
{
    public UnityEvent Activate;
    public Animator bars;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Acvtivate_Event()
    {
        Activate.Invoke();
    }

    public void Deactivate_Bars()
    {
        bars.SetBool("Stay", false);
    }

    public void Activate_Bars()
    {
        bars.SetBool("Stay", true);
    }
}
