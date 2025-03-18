using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour
{
    public GameObject continue_button;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_Scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

    public void Continue()
    {
        PlayerData data = Save_System.Load_Player();
        SceneManager.LoadScene(data.scene);
    }
}
