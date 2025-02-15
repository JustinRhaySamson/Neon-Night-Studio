using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{
    Animator anim;
    public bool exploding = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (!exploding)
        {
            anim.SetBool("Exploding", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        Object.Destroy(gameObject);
    }
}
