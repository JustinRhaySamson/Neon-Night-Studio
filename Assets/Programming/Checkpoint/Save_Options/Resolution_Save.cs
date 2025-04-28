using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Resolution_Save : MonoBehaviour
{
    Player_Store_Data player_store_data;
    public int value;
    TMP_Dropdown dropdown;
    void Start()
    {
        player_store_data = FindObjectOfType<Player_Store_Data>();
        dropdown = GetComponent<TMP_Dropdown>();
        value = player_store_data.resolution;
        dropdown.value = value;
        dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
