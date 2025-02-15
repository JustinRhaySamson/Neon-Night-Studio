using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex_Projectiles : MonoBehaviour
{
    public Transform rot_trans;
    public GameObject projectile;
    public float shooting_time = 0.1f;
    public float force = 1;
    public float bullet_number = 8;
    public int roating_speed = 1;


    Transform parent_trasnform;
    int value = 0;
    // Start is called before the first frame update
    void Start()
    {
        parent_trasnform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DEParent()
    {
        transform.parent = null;
    }

    public void INParent()
    {
        transform.parent = parent_trasnform;
    }

    public void Start_Shooting()
    {
        value = 0;
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shooting_time);
            transform.rotation = Quaternion.Euler(0, 0 + value, 0);
            for (int i = 0; i < bullet_number; i++)
            {
                GameObject bullet = Instantiate(projectile, transform.position,
                Quaternion.Euler(rot_trans.rotation.x, rot_trans.rotation.y + i * 360/bullet_number + value,
                rot_trans.rotation.z)) ;

                bullet.transform.localScale = new Vector3 (.5f,.5f,.5f);

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(bullet.transform.forward * force, ForceMode.Impulse);
            }
            value = value + roating_speed;
        } 
    }

    public void Stop_Shooting()
    {
        StopAllCoroutines();
    }
}
