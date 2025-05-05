using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class End_Screen_Button_Select : MonoBehaviour
{
    public GameObject title_button;
    public GameObject quit_button;

    bool mouse = false;
    void Start()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(title_button, new BaseEventData(eventSystem));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detect_Mouse(InputAction.CallbackContext callbackContext)
    {
        if (!mouse)
        {
            mouse = true;
        }
    }

    public void Detect_Controller(InputAction.CallbackContext callbackContext)
    {
        if (mouse)
        {
            mouse = false;
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(title_button, new BaseEventData(eventSystem));
        }
    }
}
