using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public string scene;
    public string checkpoint_name;
    public int enemies_killed;
    public bool full_screen;
    public int resolution;
    public float text_speed;
    public float master_volume;
    public float music_volume;
    public float SFX_volume;

    public PlayerData(Player_Store_Data player)
    {
        scene = player.scene;
        checkpoint_name = player.checkpoint_name;
        enemies_killed = player.enemies_killed;
        full_screen = player.full_screen;
        resolution = player.resolution;
        text_speed = player.text_speed;
        master_volume = player.master_volume;
        music_volume = player.music_volume;
        SFX_volume = player.SFX_volume;
    }
}
