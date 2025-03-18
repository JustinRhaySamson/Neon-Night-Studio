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
    public Animator animator;

    public bool restartShooting;

    public OneShotSender OneShotSender;

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

    public void Shoot_Now()
    {
        GameObject bullet2 = Instantiate(bullet, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet2.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * force, ForceMode.Impulse);

        //AUDIO
        OneShotSender.PlayOneShot(1);

    }

    public void Stop_Shooting_Now()
    {
        StopCoroutine(Shoot_Now_Coroutine());
    }

    IEnumerator Shoot_Now_Coroutine()
    {
        yield return new WaitForSeconds(.4f); 
    }
}
