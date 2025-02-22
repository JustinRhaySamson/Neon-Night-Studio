using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Show_Controls : MonoBehaviour
{
    public GameObject controls;
    bool active = false;
    public GameObject reset_button;
    bool reset_active = false;
    public GameObject resume_button;
    public GameObject pause_menu;
    public RectTransform arrow;
    void Start()
    {
        controls.SetActive(false);
        reset_button.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void Show_Controls_UI(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            print("I pressed Menu");
            active = !active;
            pause_menu.SetActive(active);
            var eventSystem = EventSystem.current;
            if (active)
            {
                Time.timeScale = 0f;
                eventSystem.SetSelectedGameObject(resume_button, new BaseEventData(eventSystem));
            }
            else if (!active)
            {
                Time.timeScale = 1;
                eventSystem.SetSelectedGameObject(null, new BaseEventData(eventSystem));
            }
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

    public void Resume_Button()
    {
        active = !active;
        pause_menu.SetActive(active);
        Time.timeScale = 1;
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null, new BaseEventData(eventSystem));
    }
}
