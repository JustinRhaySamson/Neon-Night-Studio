using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex_Projectiles : MonoBehaviour
{
    public Transform rot_trans;
    public GameObject projectile;
    public GameObject spawner;
    public float shooting_time = 0.1f;
    public float force = 1;
    public float bullet_number = 8;
    public int roating_speed = 1;
    public float bullet_scale = 0.5f;


    int value = 0;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DEParent()
    {
        
    }

    public void INParent()
    {
        
    }

    public void Start_Shooting()
    {
        value = 0;
        started = true;
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shooting_time);
            Quaternion rotation_angle = Quaternion.Euler(0, 0 + value, 0);
            for (int i = 0; i < bullet_number; i++)
            {
                GameObject bullet = Instantiate(projectile, transform.position,
                Quaternion.Euler(rotation_angle.x, rotation_angle.y + i * 360/bullet_number + value,
                rotation_angle.z)) ;

                bullet.transform.localScale = new Vector3 (bullet_scale, bullet_scale, bullet_scale);

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);
            }
            value = value + roating_speed;
        } 
    }

    public void Stop_Shooting()
    {
        started = false;
        StopAllCoroutines();
    }

    public void Restart_Shooting()
    {
        if (started)
        {
            StartCoroutine(Shooting());
        }
    }

    public void Rolling_Tunder_Bullets()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject bullet = Instantiate(projectile, transform.position,
            Quaternion.Euler(0, transform.parent.eulerAngles.y - 90 + 180*i,
            0));

            bullet.transform.localScale = new Vector3(bullet_scale, bullet_scale, bullet_scale);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);
        }
    }

    public void Flash_Step_Bullets()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(projectile, transform.position,
            Quaternion.Euler(0, transform.parent.eulerAngles.y + i * 180 / 5 - 70,
            0));

            bullet.transform.localScale = new Vector3(bullet_scale, bullet_scale, bullet_scale);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);
        }
    }

    public void Lightning_Spwaner(int mult)
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject bullet = Instantiate(spawner, transform.position,
            Quaternion.Euler(0, transform.parent.eulerAngles.y - 90 + 180 * i + 90 * mult,
            0));

            bullet.transform.localScale = new Vector3(bullet_scale, bullet_scale, bullet_scale);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);
        }
    }
}
