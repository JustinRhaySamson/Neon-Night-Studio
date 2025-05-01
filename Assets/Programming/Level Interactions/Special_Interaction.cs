using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Special_Interaction : MonoBehaviour
{
    Player_Interaction playerInteraction;

    Special_Interaction interaction;

    public UnityEvent action;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<Special_Interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            playerInteraction = other.GetComponent<Player_Interaction>();
            playerInteraction.Set_Interaction(interaction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Invincible"))
        {
            playerInteraction.Null_Interaction();
        }
    }

    public void Activate_Interaction()
    {
        action.Invoke();
    }
}
