using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Player_Health : MonoBehaviour
{
    public int HP = 2;
    public int max_HP = 2;
    GameObject UI_Text;
    TMP_Text UI_HP;
    GameObject slider;
    Slider slider_component;
    float heal_start = 0;
    float heal_end = 1.7f;
    bool healing = false;

    Player_Controller controller;

    private void Start()
    {
        UI_Text = GameObject.Find("HP number");
        UI_HP = UI_Text.GetComponent<TMP_Text>();
        UI_HP.text = HP.ToString();
        slider = GameObject.Find("Heal_Timer");
        slider_component = slider.GetComponent<Slider>();
        controller = gameObject.GetComponent<Player_Controller>();
    }

    public void Get_Hit()
    {
        HP--;
        UI_HP.text = HP.ToString();
        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Heal(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (HP < max_HP && controller.public_input == Vector3.zero)
            {
                heal_start = Time.time;
                healing = true;
                slider_component.value = 0;
                print(healing + " " + heal_start);
            }
        }
        if (callbackContext.canceled)
        {
            healing = false;
            print(healing);
        }
    }

    private void Update()
    {
        if (healing)
        {
            slider_component.value = Time.time - heal_start;
            if (Time.time > heal_start + heal_end)
            {
                HP++;
                UI_HP.text = HP.ToString();
                heal_start = Time.time;
                slider_component.value = 0;
            }
        }

        if (HP >= max_HP)
        {
            healing = false;
        }
    }
}
