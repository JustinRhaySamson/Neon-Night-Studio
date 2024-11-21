using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Bullet : MonoBehaviour
{
    GameObject Manager;
    Timemanager time_manager;
    Basic_Bullet basic_bullet;
    ArrayExtensionMethods ae;
    Rigidbody rb;

    Vector3 forces;

    public int velocity;

    void Start()
    {
        //StartCoroutine(Death());
        basic_bullet = GetComponent<Basic_Bullet>();
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        time_manager.bullets = (Basic_Bullet[])ae.AddToArray(basic_bullet, time_manager.bullets);
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Player_Health player_Health = player.GetComponent<Player_Health>();
            player_Health.Get_Hit();
        }
        time_manager.bullets = (Basic_Bullet[])ae.Remove(basic_bullet, time_manager.bullets);
        Destroy(gameObject);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        time_manager.bullets = (Basic_Bullet[])ae.Remove(basic_bullet, time_manager.bullets);
        Destroy(gameObject);
    }

    public void StopBullet()
    {
        forces = rb.velocity;
        rb.velocity = Vector3.zero;
        //StopCoroutine(Death());
    }

    public void RestartBullet()
    {
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
    }
}
