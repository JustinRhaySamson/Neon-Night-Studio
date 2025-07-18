using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Store_Data : MonoBehaviour
{
    public bool start_screen = false;
    public string scene;
    public string checkpoint_name = "Checkpont 0";
    public string origonal_checkpoint_name = "Checkpont 0";
    public int enemies_killed;
    public bool full_screen = true;
    public int resolution;
    public float text_speed = -.02f;
    public float master_volume = 1;
    public float music_volume = .5f;
    public float SFX_volume = .5f;
    public int boss_dialogues = 0;
    public int boss_phase2 = 0;
    public GameObject[] boss_dialogue_list;
    public GameObject[] boss_activator_list;

    Room_Counter room_counter;
    public Boss_HP[] boss_HP;


    void Awake()
    {
        if (!start_screen)
        {
            scene = SceneManager.GetActiveScene().name;
            //room_counter = GameObject.Find("Room_Counter").GetComponent<Room_Counter>();
            boss_HP = FindObjectsOfType<Boss_HP>();
        }
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
        print(data.scene);
        checkpoint_name = data.checkpoint_name;
        enemies_killed = data.enemies_killed;
        full_screen = data.full_screen;
        resolution = data.resolution;
        text_speed = data.text_speed;
        master_volume = data.master_volume;
        music_volume = data.music_volume;
        SFX_volume = data.SFX_volume;
        boss_dialogues = data.boss_dialogues;
        Deactivate_Boss_Dialogues();
        boss_phase2 = data.boss_phase2;
        Change_Phase2();

        //SceneManager.LoadScene(scene);
        
        GameObject checkpoint = GameObject.Find(checkpoint_name);
        Transform chekpoint_position = checkpoint.transform;
        transform.position = chekpoint_position.position;
    }

    public void Reset_Level()
    {
        checkpoint_name = origonal_checkpoint_name;
        scene = SceneManager.GetActiveScene().name;
        enemies_killed = 0;
        boss_dialogues = 0;
        boss_phase2 = 0;
        Save_player();
        SceneManager.LoadScene(scene);
    }

    public void New_Game(string level1)
    {
        checkpoint_name = origonal_checkpoint_name;
        scene = level1;
        enemies_killed = 0;
        boss_dialogues = 0;
        boss_phase2 = 0;
        Save_player();
    }

    public void Full_Screen(bool fullscreen)
    {
        full_screen = fullscreen;
    }

    public void Resolution(int res_number)
    {
        resolution = res_number;
    }

    public void Text_Speed(float speed)
    {
        text_speed = speed;
    }

    public void Increase_Boss_Dialogues()
    {
        boss_dialogues++;
    }

    void Deactivate_Boss_Dialogues()
    {
        for (int i = 0; i < boss_dialogues; i++)
        {
            boss_dialogue_list[i].SetActive(false);
            boss_activator_list[i].SetActive(true);
        }
    }

    public void Increase_Boss_Phase2()
    {
        boss_phase2++;
    }

    void Change_Phase2()
    {
        switch (boss_phase2)
        {
            case 1:
                boss_HP[2].Switch_Activators();
                break;
            case 2:
                boss_HP[0].Switch_Activators();
                boss_HP[2].Switch_Activators();
                break;
            case 3:
                boss_HP[0].Switch_Activators();
                boss_HP[1].Switch_Activators();
                boss_HP[2].Switch_Activators();
                break;
        }
    }
}
