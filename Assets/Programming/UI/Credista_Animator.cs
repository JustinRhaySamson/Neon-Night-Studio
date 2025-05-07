using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credista_Animator : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Button title_button;
    [SerializeField] Button quit_button;
    [SerializeField] Image title_image;
    [SerializeField] Image quit_image;
    [SerializeField] RawImage video;
    [SerializeField] bool start_screen = false;
    void Awake()
    {
        Time.timeScale = 1;
        if (!start_screen)
        {
            StartCoroutine(Activate_Buttons());
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Activate_Buttons()
    {
        yield return new WaitForSeconds(26.5f);
        title_button.interactable = true;
        quit_button.interactable = true;
        title_image.enabled = true;
        quit_image.enabled = true;
        video.enabled = false;
    }
}
