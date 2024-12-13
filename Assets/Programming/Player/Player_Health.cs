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
    GameObject health_1;
    GameObject health_2;

    public GameObject VFX,HealVFX;

    float slider_time;
    float slider_value;
    bool cooldown = false;

    Player_Controller controller;
    Animator animator;

    private void Start()
    {
        UI_Text = GameObject.Find("HP number");
        UI_HP = UI_Text.GetComponent<TMP_Text>();
        UI_HP.text = HP.ToString();
        slider = GameObject.Find("Slider_new");
        slider_component = slider.GetComponent<Slider>();
        controller = gameObject.GetComponent<Player_Controller>();
        health_1 = GameObject.Find("Health1 2");
        health_2 = GameObject.Find("Health1");
        animator = GetComponent<Animator>();
    }

    public void Get_Hit()
    {
        HP--;
        UI_HP.text = HP.ToString();
        if(HP > 0)
        {
            animator.SetBool("Stagger", true);
        }
        if (HP <= 0)
        {
            health_2.SetActive(false);
            animator.SetBool("Dead", true);
        }
    }

    public void Heal(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && slider_component.value == slider_component.maxValue)
        {
            if (HP < max_HP && controller.public_input == Vector3.zero)
            {
                HealVFX.SetActive(true);
                heal_start = Time.time;
                healing = true;
                slider_component.maxValue = heal_end;
                slider_component.value = heal_end;
                print(healing + " " + heal_start);
            }
        }
        if (callbackContext.canceled)
        {
            if (healing)
            {
                HealVFX.SetActive(false);
                slider_time = Time.time;
                slider_component.maxValue = 4;
                slider_component.value = slider_component.value * 2.35294117647f;
                slider_value = slider_component.value;
                cooldown = true;
            }
            healing = false;
            print(healing);
        }
    }

    private void Update()
    {
        if (healing)
        {
            slider_component.value = heal_end - (Time.time - heal_start);
            if (Time.time > heal_start + heal_end)
            {
                HP++;
                UI_HP.text = HP.ToString();
                heal_start = Time.time;
                cooldown = true;
                slider_component.value = slider_component.value * 2.35294117647f;
                slider_value = slider_component.value;
                slider_component.maxValue = 4f;
                slider_time = Time.time;
                HealVFX.SetActive(false);
            }
        }

        if (!healing && cooldown)
        {
            slider_component.value = (Time.time - slider_time) + slider_value;

            if (slider_component.value == slider_component.maxValue)
            {
                cooldown = false;
            }
        }

        if (HP >= max_HP)
        {
            healing = false;
        }

        if (HP < 2)
        {
            health_1.SetActive(false);
        }

        else if (HP == 2)
        {
            health_1.SetActive(true);
        }
    }

    public void Restart_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void False_Dead()
    {
        animator.SetBool("Dead", false);
    }

    public void False_Stagger()
    {
        animator.SetBool("Stagger", false);
        VFX.SetActive(true);
    }

    public void Disable()
    {
        VFX.SetActive(false);
    }
}
