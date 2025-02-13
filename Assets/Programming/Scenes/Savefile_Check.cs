using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;

public class Savefile_Check : MonoBehaviour
{
    public GameObject continue_button;
    public GameObject new_game_button;
    
    void Start()
    {
        string path = Application.persistentDataPath + "/player_data.data";
        print(path);
        if (File.Exists(path))
        {
            
        }
        else
        {
            continue_button.SetActive(false);
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(new_game_button, new BaseEventData(eventSystem));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
