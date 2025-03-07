using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Activate_Hitbox : MonoBehaviour
{
    public Collider hitbox;
    // Start is called before the first frame update
    public void Activate_Hitbox()
    {
        hitbox.enabled = true;
    }

    public void Deactivate_Hitbox()
    {
        hitbox.enabled = false;
    }
}
