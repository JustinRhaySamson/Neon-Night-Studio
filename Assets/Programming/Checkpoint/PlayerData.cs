using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public string scene;
    public string checkpoint_name;
    public int enemies_killed;

    public PlayerData(Player_Store_Data player)
    {
        scene = player.scene;
        checkpoint_name = player.checkpoint_name;
        enemies_killed = player.enemies_killed;
    }
}
