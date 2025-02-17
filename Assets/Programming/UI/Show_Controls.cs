using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Show_Controls : MonoBehaviour
{
    public GameObject controls;
    bool active = false;
    public GameObject reset_button;
    bool reset_active = false;
    void Start()
    {
        controls.SetActive(false);
        reset_button.SetActive(false);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            reset_active = !reset_active;
            reset_button.SetActive(reset_active);
        }
    }
}
