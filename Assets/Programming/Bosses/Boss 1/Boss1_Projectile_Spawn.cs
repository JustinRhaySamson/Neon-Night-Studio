using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Projectile_Spawn : MonoBehaviour
{
    public GameObject spwaner1;
    public GameObject spwaner2;
    public GameObject rotating_spawner;
    public Collider weapon_collider;
    public Collider weapon_collider2;
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
        GameObject explosion_object = Instantiate(explosion, spwaner1.transform.position, Quaternion.Euler(0,0,0));
        explosion_object.transform.localScale = transform.localScale;
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

    public void Rolling_Thunder_Bullets()
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Rolling_Tunder_Bullets();
    }

    public void Spawn_Explosion2(GameObject explosion)
    {
        weapon_collider2.enabled = false;
        GameObject explosion_object = Instantiate(explosion, spwaner2.transform.position, Quaternion.Euler(0, 0, 0));
        explosion_object.transform.localScale = transform.localScale;
    }

    public void Activate_Weapon2()
    {
        weapon_collider2.enabled = true;
    }
}
