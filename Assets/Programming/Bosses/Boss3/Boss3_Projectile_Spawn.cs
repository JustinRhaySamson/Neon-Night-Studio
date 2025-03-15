using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_Projectile_Spawn : MonoBehaviour
{
    public GameObject spwaner1;
    public GameObject spwaner2;
    public GameObject center_spawner;
    public Collider weapon_collider;
    public Collider weapon_collider2;
    public GameObject icicles_ground;
    public GameObject shattering_snowflakes;
    public GameObject bullets_3;
    public GameObject ice_walls;
    public GameObject divine_punishment_projectiles;
    public Transform player_transform;
    public Transform teleport_points_parent;

    int orbs_number = -1;
    float force = 20;

    public GameObject ice_walls_spawn;
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

    public void Spawn_Icicles_Ground()
    {
        GameObject icicles_spawn = Instantiate(icicles_ground, gameObject.transform.position, gameObject.transform.rotation);
        //icicles_spawn.transform.parent = gameObject.transform;
    }

    public void Spawn_Bullet()
    {
        GameObject bullet = Instantiate(bullets_3, center_spawner.transform.position,
            transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);
    }

    public void Shattering_Snowflakes()
    {
        GameObject expanding_wave_spawn = Instantiate(shattering_snowflakes,
            center_spawner.transform.position,
            transform.rotation * Quaternion.Euler(0, -90, 0));
    }

    public void Spawn_Divine_Punishment()
    {
        GameObject divine_spawn = Instantiate(divine_punishment_projectiles,
            center_spawner.transform.position,
            transform.rotation * Quaternion.Euler(0, -90, 0));
    }

    public void Spawn_Ice_Walls()
    {
        ice_walls_spawn = Instantiate(ice_walls, transform.position, Quaternion.identity);
    }

    public void Rotate_Walls()
    {
        float angle = Mathf.Atan2(transform.position.x - player_transform.position.x, 
            transform.position.z - player_transform.position.z) * Mathf.Rad2Deg;
        print("The angle between player and boss3 is: " + angle);

        if(angle > 120 && angle < 180)
        {
            ice_walls_spawn.transform.rotation = Quaternion.Euler(0, 0, 0);
            teleport_points_parent.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (angle > 60 && angle < 120)
        {
            ice_walls_spawn.transform.rotation = Quaternion.Euler(0, -60, 0);
            teleport_points_parent.transform.rotation = Quaternion.Euler(0, -60, 0);
        }
        else if(angle > 0 && angle < 60)
        {
            ice_walls_spawn.transform.rotation = Quaternion.Euler(0, -120, 0);
            teleport_points_parent.transform.rotation = Quaternion.Euler(0, -120, 0);
        }
        else if(angle > -60 && angle < 0)
        {
            ice_walls_spawn.transform.rotation = Quaternion.Euler(0, 180, 0);
            teleport_points_parent.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(angle > -120 && angle < -60)
        {
            ice_walls_spawn.transform.rotation = Quaternion.Euler(0, 120, 0);
            teleport_points_parent.transform.rotation = Quaternion.Euler(0, 120, 0);
        }
        else if(angle > -180 && angle < -120)
        {
            ice_walls_spawn.transform.rotation = Quaternion.Euler(0, 60, 0);
            teleport_points_parent.transform.rotation = Quaternion.Euler(0, 60, 0);
        }
    }
}
