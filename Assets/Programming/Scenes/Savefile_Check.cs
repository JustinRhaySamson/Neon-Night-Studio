using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Savefile_Check : MonoBehaviour
{
    public GameObject continue_button;
    public GameObject new_game_button;

    bool mouse = false;
    bool saved;

    void Start()
    {
        string path = Application.persistentDataPath + "/player_data.data";
        print(path);
        if (File.Exists(path))
        {
            saved = true;
        }
        else
        {
            continue_button.SetActive(false);
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(new_game_button, new BaseEventData(eventSystem));
            saved = false;
        }
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
            if (saved)
            {
                eventSystem.SetSelectedGameObject(continue_button, new BaseEventData(eventSystem));
            }
            else if (!saved)
            {
                eventSystem.SetSelectedGameObject(new_game_button, new BaseEventData(eventSystem));
            }
        }
    }

}
