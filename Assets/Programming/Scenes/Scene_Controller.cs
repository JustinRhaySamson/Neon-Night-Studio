using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
