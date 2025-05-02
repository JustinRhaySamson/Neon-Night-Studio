using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Speed_Save : MonoBehaviour
{
    Player_Store_Data player_store_data;
    DialogueManager dialogueManager;
    public Slider speedSlider;
    float speed = -.02f;
    void Start()
    {
        player_store_data = FindObjectOfType<Player_Store_Data>();
        dialogueManager = GetComponent<DialogueManager>();
        speed = player_store_data.text_speed;
        speedSlider.value = speed;
        dialogueManager.speed = Mathf.Abs(speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
