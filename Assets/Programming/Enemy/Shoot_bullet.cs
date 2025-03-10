using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_bullet : MonoBehaviour
{
    public float reload_time;
    public int force;
    public GameObject bullet;
    public Transform firepoint;
    public bool not_stopped = true;

    public bool restartShooting;

    void Start()
    {
        //StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*public void RestartShooting()
    {
        if (restartShooting)
        {
            restartShooting = false;
            StopAllCoroutines();
            StartCoroutine(Shoot());
        }
    }*/

    public void StopShooting()
    {
        StopCoroutine(Shoot());
    }

    public void StartShooting()
    {
        StartCoroutine(Shoot());
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
