using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Projectile_Spawn : MonoBehaviour
{
    public GameObject spwaner1;
    public GameObject rotating_spawner;
    public Collider weapon_collider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn_Explosion(GameObject explosion)
    {
        Deactivate_Weapon();
        Instantiate(explosion, spwaner1.transform);
    }

    public void Spawn_Rotation()
    {
        weapon_collider.enabled = true;
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Start_Shooting();
    }

    public void Stop_Rotation()
    {
        weapon_collider.enabled = false;
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Stop_Shooting();
    }

    public void Activate_Weapon()
    {
        weapon_collider.enabled = true;
    }

    public void Deactivate_Weapon()
    {
        weapon_collider.enabled = false;
    }


}
