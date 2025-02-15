using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Projectile_Spawn : MonoBehaviour
{
    public GameObject spwaner1;
    public GameObject rotating_spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn_Explosion(GameObject explosion)
    {
        Instantiate(explosion, spwaner1.transform);
    }

    public void Spawn_Rotation()
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Start_Shooting();
    }

    public void Stop_Rotation()
    {
        Vortex_Projectiles vortex_Projectiles = rotating_spawner.GetComponent<Vortex_Projectiles>();
        vortex_Projectiles.Stop_Shooting();
    }


}
