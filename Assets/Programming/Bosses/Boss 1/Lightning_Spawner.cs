using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Spawner : MonoBehaviour
{
    public GameObject Lightning;
    Animator anim;

    GameObject Manager;
    Timemanager time_manager;
    Lightning_Spawner lightning_Spawner;
    ArrayExtensionMethods ae;
    Rigidbody rb;
    Vector3 forces;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lightning_Spawner = GetComponent<Lightning_Spawner>();
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        time_manager.lightning_spawns = (Lightning_Spawner[])ae.AddToArray(lightning_Spawner, time_manager.lightning_spawns);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn_Lightning()
    {
        GameObject lightning_Spawn = Instantiate(Lightning);
        lightning_Spawn.transform.parent = null;
        lightning_Spawn.transform.position = gameObject.transform.position;
    }

    public void Time_Stop()
    {
        anim.SetFloat("Speed", 0);
        forces = rb.velocity;
        rb.velocity = Vector3.zero;
    }

    public void Time_Reset()
    {
        anim.SetFloat("Speed", 1);
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") || !other.CompareTag("Invincible") || !other.CompareTag("Boss"))
        {
            time_manager.lightning_spawns = (Lightning_Spawner[])ae.Remove(lightning_Spawner, time_manager.lightning_spawns);
            Destroy(gameObject);
        }
    }
}
