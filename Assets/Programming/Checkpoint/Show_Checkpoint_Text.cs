using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Checkpoint_Text : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Activate_Text()
    {
        animator.SetBool("Active", true);
    }

    public void Inactive_Text()
    {
        animator.SetBool("Active", false);
    }
}
