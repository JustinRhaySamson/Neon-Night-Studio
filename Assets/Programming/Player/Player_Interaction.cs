using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Interaction : MonoBehaviour
{
    Special_Interaction special_interaction;

    bool dialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interaction_Press(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && special_interaction != null)
        {
            special_interaction.Activate_Interaction();
        }

        if (callbackContext.performed)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public void Set_Interaction(Special_Interaction script)
    {
        special_interaction = script;
    }

    public void Null_Interaction()
    {
        special_interaction = null;
    }

    public void Change_Dialogue()
    {
        dialogue = !dialogue;
    }
}
