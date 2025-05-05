using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;


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
    public GameObject load_Screen;
    bool full_screened = true;
    bool mouse = false;

    bool normal_pause = false;
    bool controls_pause = false;
    bool options_pause = false;

    VCA Master;
    VCA Music;
    VCA SFX;
    VCA Pause;
    float master_volume = 2;
    float music_volume = 1f;
    float SFX_volume = 1f;
    float pause_volume = 1;
    public Slider Master_slider;
    public Slider Music_slider;
    public Slider SFX_slider;
    Player_Store_Data player_store_data;

    private void Awake()
    {
        load_Screen.SetActive(true);
    }

    void Start()
    {
        player_store_data = FindObjectOfType<Player_Store_Data>();
        controls.SetActive(false);
        reset_button.SetActive(false);
        Time.timeScale = 1;
        normal_pause = false;
        controls_pause = false;
        options_pause = false;
        Master = RuntimeManager.GetVCA("vca:/MASTER");
        Music = RuntimeManager.GetVCA("vca:/MUSIC");
        SFX = RuntimeManager.GetVCA("vca:/EFFECTS");
        Pause = RuntimeManager.GetVCA("vca:/Pause Macro");
        Pause.setVolume(1);
        master_volume = player_store_data.master_volume;
        music_volume = player_store_data.music_volume;
        SFX_volume = player_store_data.SFX_volume;
        Master_slider.value = master_volume;
        Music_slider.value = music_volume;
        SFX_slider.value = SFX_volume;
        Pause.getVolume(out pause_volume);
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
                normal_pause = true;
                controls_pause = false;
                options_pause = false;
                Pause.setVolume(0);
                print("The menu volume is: " + pause_volume);
            }
            else if (!active)
            {
                Time.timeScale = 1;
                eventSystem.SetSelectedGameObject(null, new BaseEventData(eventSystem));
                normal_pause = false;
                controls_pause = false;
                options_pause = false;
                Pause.setVolume(pause_volume);
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
        Pause.setVolume(pause_volume);
    }

    public void Options_Menu()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(full_screen_toggle, new BaseEventData(eventSystem));
        RectTransform fullscree_transform = full_screen_toggle.GetComponent<RectTransform>();
        arrow.position = new Vector3(fullscree_transform.position.x * .18f,
            fullscree_transform.position.y,
            fullscree_transform.position.z);
        vertical_list_menu.SetActive(false);
        options_menu.SetActive(true);
        normal_pause = false;
        controls_pause = false;
        options_pause = true;
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
        normal_pause = true;
        controls_pause = false;
        options_pause = false;
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
        normal_pause = false;
        controls_pause = true;
        options_pause = false;
    }

    public void Detect_Controller(InputAction.CallbackContext callbackContext)
    {
        if (active && mouse)
        {
            mouse = false;
            var eventSystem = EventSystem.current;
            if (normal_pause)
            { 
                eventSystem.SetSelectedGameObject(resume_button, new BaseEventData(eventSystem));
                RectTransform resume_transform = resume_button.GetComponent<RectTransform>();
                arrow.position = new Vector3(resume_transform.position.x * .67f,
                    resume_transform.position.y,
                    resume_transform.position.z);
            }
            else if (controls_pause)
            {
                eventSystem.SetSelectedGameObject(back_pause, new BaseEventData(eventSystem));
                RectTransform Back_Pause_transform = back_pause.GetComponent<RectTransform>();
                arrow.position = new Vector3(Back_Pause_transform.position.x * .75f,
                    Back_Pause_transform.position.y,
                    Back_Pause_transform.position.z);
            }
            else if (options_pause)
            {
                eventSystem.SetSelectedGameObject(full_screen_toggle, new BaseEventData(eventSystem));
                RectTransform fullscree_transform = full_screen_toggle.GetComponent<RectTransform>();
                arrow.position = new Vector3(fullscree_transform.position.x * .3f,
                    fullscree_transform.position.y,
                    fullscree_transform.position.z);
            }
        }
    }

    public void Detect_Mouse(InputAction.CallbackContext callbackContext)
    {
        if (active && !mouse)
        {
            mouse = true;
        }
    }

    public void Master_Change(float number)
    {
        master_volume = number;
        player_store_data.master_volume = master_volume;
        Master.setVolume(master_volume);
    }

    public void Music_Change(float number)
    {
        music_volume = number;
        player_store_data.music_volume = music_volume;
        Music.setVolume(music_volume);
    }

    public void SFX_Change(float number)
    { 
        SFX_volume = number;
        player_store_data.SFX_volume = SFX_volume;
        SFX.setVolume(SFX_volume);
    }
}
