using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Arena_Script : MonoBehaviour
{
    public GameObject player;
    public GameObject rising_platform;
    public MeshCollider arena_collider;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Child_Player()
    {
        player.transform.parent = rising_platform.transform;
    }

    public void Dechild_Player()
    {
        player.transform.parent = null;
    }

    public void Activate_Collider()
    {
        arena_collider.enabled = true;
    }

    public void Deactivate_Collider()
    {
        arena_collider.enabled = false;
    }

    public void Start_Fight()
    {
        animator.SetBool("Start_Fight", true);
    }

    public void End_Fight()
    {
        animator.SetBool("Go_Down", true);
    }
}
