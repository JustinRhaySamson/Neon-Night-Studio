using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_bullet : MonoBehaviour
{
    public int reload_time;
    public int force;
    public GameObject bullet;
    public Transform firepoint;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(reload_time);
            GameObject bullet2 = Instantiate(bullet, firepoint.position, firepoint.rotation);
            Rigidbody rb = bullet2.GetComponent<Rigidbody>();
            rb.AddForce(firepoint.forward * force, ForceMode.Impulse);
        }
    }
}
