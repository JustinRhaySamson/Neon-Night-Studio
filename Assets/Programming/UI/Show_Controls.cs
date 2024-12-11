using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Show_Controls : MonoBehaviour
{
    GameObject controls;
    bool active = false;
    void Start()
    {
        controls = GameObject.Find("Controls");
        controls.SetActive(false);
    }

    // Update is called once per frame
    public void Show_Controls_UI(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            print("I pressed Menu");
            active = !active;
            controls.SetActive(active);
        }
    }
}
