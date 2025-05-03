using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Spawn_Projectiles : MonoBehaviour
{
    public GameObject ice_projectile;
    public Transform center;
    float force = 15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn_Ice()
    {
        for (int i = 0; i < 8; i++) 
        {
            GameObject projectile = Instantiate(ice_projectile, center.transform.position, 
                gameObject.transform.rotation * Quaternion.Euler(0, i* 360/8,0));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(projectile.transform.forward * force, ForceMode.Impulse);
        }
    }
}
