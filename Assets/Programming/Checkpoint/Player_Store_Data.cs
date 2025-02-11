using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Store_Data : MonoBehaviour
{
    public string scene;
    public string checkpoint_name = "Checkpont 0";
    public string origonal_checkpoint_name = "Checkpont 0";

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        Load_player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Checkpoint(string name)
    {
        checkpoint_name = name;
        Save_player();
        print("I saved");
    }

    public void Save_player()
    {
        Save_System.Save_Player(this);
    }

    public void Load_player()
    {
        PlayerData data = Save_System.Load_Player();

        scene = data.scene;
        checkpoint_name = data.checkpoint_name;

        //SceneManager.LoadScene(scene);
        
        GameObject checkpoint = GameObject.Find(checkpoint_name);
        Transform chekpoint_position = checkpoint.transform;
        transform.position = chekpoint_position.position;
    }

    public void Reset_Level()
    {
        checkpoint_name = origonal_checkpoint_name;
        Save_player();
        SceneManager.LoadScene(scene);
    }
}
