using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Script : MonoBehaviour
{
    Animator animator;
    float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = animator.GetFloat("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
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
