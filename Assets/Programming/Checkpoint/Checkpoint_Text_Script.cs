using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Text_Script : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void Active_Text()
    {
        animator.SetBool("Active", true);
    }

    public void Inactive_Text()
    {
        animator.SetBool("Active", false);
    }
}
