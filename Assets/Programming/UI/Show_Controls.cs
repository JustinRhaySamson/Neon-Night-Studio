using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Show_Controls : MonoBehaviour
{
    public GameObject controls;
    [HideInInspector] public bool active = false;
    public GameObject reset_button;
    bool reset_active = false;
    public GameObject resume_button;
    public GameObject pause_menu;
    public GameObject vertical_list_menu;
    public RectTransform arrow;
    public GameObject full_screen_toggle;
    public GameObject options_menu;
    public GameObject controls_menu;
    public GameObject back_pause;

    bool full_screened = true;
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
            vertical_list_menu.SetActive(true);
            options_menu.SetActive(false);
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

    public void Options_Menu()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(full_screen_toggle, new BaseEventData(eventSystem));
        RectTransform fullscree_transform = full_screen_toggle.GetComponent<RectTransform>();
        arrow.position = new Vector3(fullscree_transform.position.x * .3f,
            fullscree_transform.position.y,
            fullscree_transform.position.z);
        vertical_list_menu.SetActive(false);
        options_menu.SetActive(true);
    }

    public void Back_To_Pause()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(resume_button, new BaseEventData(eventSystem));
        RectTransform resume_transform = resume_button.GetComponent<RectTransform>();
        arrow.position = new Vector3(resume_transform.position.x * .67f,
            resume_transform.position.y,
            resume_transform.position.z);
        vertical_list_menu.SetActive(true);
        options_menu.SetActive(false);
        controls_menu.SetActive(false);
    }

    public void Change_Fulscreen(bool toggle)
    {
        Screen.fullScreen = toggle;
        full_screened = toggle;
    }

    public void Change_Resolution(int i)
    {
        switch (i)
        {
            case 0:
                Screen.SetResolution(1920, 1080, full_screened);
                break;
            case 1:
                Screen.SetResolution(1280, 720, full_screened);
                break;
            case 2:
                Screen.SetResolution(640, 480, full_screened);
                break;
        }
    }

    public void Controls_Menu()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(back_pause, new BaseEventData(eventSystem));
        RectTransform Back_Pause_transform = back_pause.GetComponent<RectTransform>();
        arrow.position = new Vector3(Back_Pause_transform.position.x * .75f,
            Back_Pause_transform.position.y,
            Back_Pause_transform.position.z);
        vertical_list_menu.SetActive(false);
        controls_menu.SetActive(true);
    }
}
