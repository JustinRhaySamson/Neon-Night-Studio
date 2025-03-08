using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Projectile_Spawner : MonoBehaviour
{
    public GameObject spwaner1;
    public GameObject spwaner2;
    public GameObject center_spawner;
    public Collider weapon_collider;
    public Collider weapon_collider2;
    public GameObject lightning;
    public GameObject[] orbs = new GameObject[2];
    float force = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate_Weapon()
    {
        weapon_collider.enabled = true;
    }

    public void Deactivate_Weapon()
    {
        weapon_collider.enabled = false;
    }


    public void Activate_Weapon2()
    {
        weapon_collider2.enabled = true;
    }
}
