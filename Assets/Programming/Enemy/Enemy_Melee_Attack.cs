using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee_Attack : MonoBehaviour
{
    public Animator animator;
    public CapsuleCollider weapon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            animator.SetBool("Swing", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            animator.SetBool("Swing", false);
        }
    }

    public void Activate_Weapon()
    {
        weapon.enabled = true;
    }

    public void Deactivate_Weapon()
    {
        weapon.enabled = false;
    }


}
