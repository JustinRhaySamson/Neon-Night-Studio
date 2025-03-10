using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Player_Health : MonoBehaviour
{
    public int HP = 3;
    public int max_HP = 3;
    GameObject UI_Text;
    TMP_Text UI_HP;
    GameObject slider;
    Slider slider_component;
    float heal_start = 0;
    float heal_end = 1.7f;
    bool healing = false;
    GameObject health_1;
    GameObject health_2;
    GameObject health_3;

    public GameObject VFX,HealVFX;

    float slider_time;
    float slider_value;
    bool cooldown = false;

    Player_Controller controller;
    Animator animator;

    public float refill_timer_health = 0;

    private void Start()
    {
        UI_Text = GameObject.Find("HP number");
        UI_HP = UI_Text.GetComponent<TMP_Text>();
        UI_HP.text = HP.ToString();
        slider = GameObject.Find("Slider_new");
        slider_component = slider.GetComponent<Slider>();
        controller = gameObject.GetComponent<Player_Controller>();
        health_1 = GameObject.Find("Health1 3");
        health_2 = GameObject.Find("Health1 2");
        health_3 = GameObject.Find("Health1");
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
            health_3.SetActive(false);
            Invincible_Tag();
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
                slider_component.maxValue = 20;
                //slider_component.value = slider_component.value * 5f;
                slider_value = slider_component.value * 11.76f;
                print("The slider value is" + slider_component.value);
                print("The value of the slider should be " + slider_value);
                cooldown = true;
                refill_timer_health = 0;
            }
            healing = false;
        }
    }

    private void Update()
    {
        if (healing && !cooldown)
        {
            slider_component.value = heal_end - (Time.time - heal_start);
            if (Time.time > heal_start + heal_end)
            {
                HP++;
                refill_timer_health = 0;
                UI_HP.text = HP.ToString();
                heal_start = Time.time;
                cooldown = true;
                //slider_component.value = slider_component.value * 11.76f;
                //slider_value = slider_component.value;
                slider_time = Time.time;
                HealVFX.SetActive(false);
            }
        }

        if (!healing && cooldown)
        {
            //slider_component.maxValue = 20f;
            slider_component.value = (Time.time - slider_time) + slider_value + 3 * refill_timer_health;

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
            health_2.SetActive(false);
        }

        else if (HP == 2)
        {
            health_2.SetActive(true);
        }

        if (HP < 3)
        {
            health_1.SetActive(false);
        }

        else if (HP == 3)
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

    public void Invincible_Tag()
    {
        gameObject.tag = "Invincible";
    }

    public void Player_Tag()
    {
        gameObject.tag = "Player";
    }
}
