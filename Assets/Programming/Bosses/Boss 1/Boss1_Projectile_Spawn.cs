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
    public GameObject lightning;
    public GameObject big_lightning;
    public BoxCollider slash_hitbox;
    float force = 10;
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

    public void Spawn_Wave(GameObject wave)
    {
        GameObject wave_object = Instantiate(wave, spwaner1.transform.position, 
            gameObject.transform.rotation);
        Rigidbody rb = wave_object.GetComponent<Rigidbody>();
        rb.AddForce(wave_object.transform.forward * force, ForceMode.Impulse);
    }

    public void Spawn_Big_Lightning()
    {
        Instantiate(big_lightning, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
    }

    public void Flash_Step_Bullets()
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Flash_Step_Bullets();
    }

    public void Lightning_Spawner_1(int multi)
    {
        //Object.Destroy(gameObject);
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Lightning_Spwaner(multi);
    }

    public void Thunder_Strike_1()
    {
        Vector3 random_pos = new Vector3(transform.position.x + Random.Range(-10, 10), 
            transform.position.y,
            transform.position.z + Random.Range(-10, 10));
        GameObject lightning_spawn = Instantiate(lightning, random_pos, Quaternion.identity);
        lightning_spawn.transform.parent = null;
        lightning_spawn.transform.position = random_pos;
    }

    public void Scatter_Bolt_1()
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Scatter_Bolt_Projectiles(true);
    }

    public void Scatter_Bolt_2()
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Scatter_Bolt_Projectiles(false);
    }

    public void Scatter_Bolt_3(GameObject wave)
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Scatter_Bolt_Waves(wave);
    }

    public void Activate_Slash()
    {
        slash_hitbox.enabled = true;
    }

    public void Deactivate_Slash()
    {
        slash_hitbox.enabled = false;
    }
}
