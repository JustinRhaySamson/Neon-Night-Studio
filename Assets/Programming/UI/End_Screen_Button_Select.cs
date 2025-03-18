using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class End_Screen_Button_Select : MonoBehaviour
{
    public GameObject title_button;
    public GameObject quit_button;
    void Start()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(title_button, new BaseEventData(eventSystem));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
