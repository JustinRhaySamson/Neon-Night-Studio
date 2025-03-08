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
    public GameObject tornado;
    public GameObject bullets_3;
    public GameObject expanding_wave;
    public GameObject divine_punishment_projectiles;

    int orbs_number = -1;
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

    public void Deactivate_Weapon2()
    {
        weapon_collider2.enabled = false;
    }

    public void Activate_Orbs()
    {
        orbs_number++;
        orbs[orbs_number].SetActive(true);
    }

    public void Spawn_Tornado()
    {
        GameObject tornado_spawn = Instantiate(tornado,
            new Vector3(transform.position.x,transform.position.y + 2,transform.position.z), Quaternion.Euler(90,0,90));
        tornado_spawn.transform.SetParent(gameObject.transform);
        tornado.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void Spawn_3_Bullets()
    {
        GameObject bullets_3_spawn = Instantiate(bullets_3, spwaner1.transform.position, 
            transform.rotation * Quaternion.Euler(0,-90,0));
    }

    public void Expanding_Wave()
    {
        GameObject expanding_wave_spawn = Instantiate(expanding_wave, 
            center_spawner.transform.position, 
            transform.rotation * Quaternion.Euler(0, -90, 0));
    }

    public void Spawn_Divine_Punishment()
    {
        GameObject divine_spawn = Instantiate(divine_punishment_projectiles,
            center_spawner.transform.position,
            transform.rotation * Quaternion.Euler(0, -90, 0));
    }
}
