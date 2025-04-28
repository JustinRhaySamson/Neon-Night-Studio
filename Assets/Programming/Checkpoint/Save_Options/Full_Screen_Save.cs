using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Full_Screen_Save : MonoBehaviour
{
    Player_Store_Data player_store_data;
    Toggle toggle;
    bool fullscreen;
    void Start()
    {
        player_store_data = FindObjectOfType<Player_Store_Data>();
        toggle = GetComponent<Toggle>();
        fullscreen = player_store_data.full_screen;
        toggle.isOn = fullscreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
