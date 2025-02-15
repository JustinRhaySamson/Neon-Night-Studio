using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{
    Animator anim;
    public bool exploding = true;

    GameObject Manager;
    Timemanager time_manager;
    ArrayExtensionMethods ae;
    Explosion_Script explosion_script;
    void Start()
    {
        anim = GetComponent<Animator>();
        Manager = GameObject.Find("Time manager");
        time_manager = Manager.GetComponent<Timemanager>();
        ae = Manager.GetComponent<ArrayExtensionMethods>();
        explosion_script = GetComponent<Explosion_Script>();
        time_manager.explosions = (Explosion_Script[])ae.AddToArray(explosion_script, time_manager.explosions);
        if (!exploding)
        {
            anim.SetBool("Exploding", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        time_manager.explosions = (Explosion_Script[])ae.Remove(explosion_script, time_manager.explosions);
        Object.Destroy(gameObject);
    }

    public void Stop_Explosion()
    {
        anim.SetFloat("Speed", 0);
    }

    public void Restart_Explosion()
    {
        anim.SetFloat("Speed", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            Player_Health player_Health = player.GetComponent<Player_Health>();
            player_Health.Get_Hit();
        }
    }
}
