using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Boss_HP : MonoBehaviour
{
    public int HP;
    public int maxHP;
    int health_checks = 0;
    int health_checks2 = 0;
    public Sprite heathbar_1;
    public Sprite heathbar_2;
    GameObject slider;
    Slider slider_component;
    Animator slider_animator;
    GameObject time_manager;
    Timemanager time_Script;
    Animator animator;
    Boss1_State_Manager state_manager;
    Boss2_State_Manager state_manager2;
    Boss3_State_Manager state_manager3;
    Image healthbar_image;
    bool life_regen = false;

    bool phase1 = true;
    public GameObject phase2_dialague;

    //SOUND!!!
    OneShotSender playSound;

    [SerializeField] bool boss1 = false;
    [SerializeField] bool boss2 = false;
    [SerializeField] bool boss3 = false;

    public UnityEvent die;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Boss_HP_Slider");
        slider_component = slider.GetComponent<Slider>();
        slider_animator = slider.GetComponent <Animator>();
        time_manager = GameObject.Find("Time manager");
        time_Script = time_manager.GetComponent<Timemanager>();
        healthbar_image = GameObject.Find("Boss_Health_Image").GetComponent<Image>();
        if (boss1)
        {
            time_Script.Activate_Boss1(gameObject);
        }
        else if (boss2)
        {
            health_checks = (maxHP/4) * 3;
            health_checks2 = maxHP / 2;
            time_Script.Activate_Boss2(gameObject);
        }
        else if (boss3)
        {
            time_Script.Activate_Boss3(gameObject);
        }
        animator = gameObject.GetComponent<Animator>();
        if (boss1)
        {
            state_manager = gameObject.GetComponent<Boss1_State_Manager>();
        }
        else if (boss2)
        {
            state_manager2 = gameObject.GetComponent<Boss2_State_Manager>();
        }
        else if (boss3)
        {
            state_manager3 = gameObject.GetComponent<Boss3_State_Manager>();
        }

        playSound = gameObject.GetComponent<OneShotSender>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (life_regen)
        {
            slider_component.value = Mathf.Lerp(slider_component.value, maxHP + 30, .02f);
            if(slider_component.value >= maxHP)
            {
                life_regen = false;
            }
        }
    }

    public void Start_Fight()
    {
        slider_component.maxValue = maxHP;
        slider_component.value = HP;
        slider_animator.SetBool("Active", true);
        healthbar_image.sprite = heathbar_1;
    }

    public void Get_Hit()
    {
        //Play Hit Sound
        playSound.PlayOneShot(0);

        HP--;
        slider_component.value = HP;
        if (boss1)
        {
            if (HP <= 0 && phase1 && !life_regen)
            {
                state_manager.SwitchState(state_manager.phase2_idle_state);
                HP = maxHP;
                life_regen = true;
                animator.SetBool("Phase2", true);
                phase1 = false;
                healthbar_image.sprite = heathbar_2;
            }
            else if (HP <= 0 && !phase1 && !life_regen)
            {
                time_Script.boss1_scene = false;
                slider_animator.SetBool("Active", false);
                die.Invoke();
                Destroy(gameObject);
            }
        }
        
        else if (boss2)
        {
            if(HP <= health_checks)
            {
                health_checks = -200;
                state_manager2.SwitchState(state_manager2.storm_state);
            }

            else if(HP <= health_checks2)
            {
                health_checks2 = -200;
                state_manager2.SwitchState(state_manager2.storm_state);
            }

            else if (HP <= 0 && phase1 && !life_regen)
            {
                die.Invoke();
                GameObject rotating_orbs = GameObject.Find("Rotating_Orbs");
                Tornado_Script tornado = rotating_orbs.GetComponent<Tornado_Script>();
                VFX_Time_Stop vfx = rotating_orbs.GetComponent<VFX_Time_Stop>();
                Particle_Time_Stop particle_Time_Stop = GetComponent<Particle_Time_Stop>();
                particle_Time_Stop.Die_Particles();
                vfx.Die();
                tornado.Die();
                //Object.Destroy(rotating_orbs);
                //time_Script.boss2_Scene = false;
                slider_animator.SetBool("Active", false);
                animator.SetBool("Staggered", true);
                //Destroy(gameObject);
            }
        }

        else if (boss3)
        {
            if (HP <= 0 && phase1 && !life_regen)
            {
                slider_animator.SetBool("Active", false);
                state_manager3.SwitchState(state_manager3.idle2_state);
                //life_regen = true;
                animator.SetBool("Stagger", true);
                healthbar_image.sprite = heathbar_2;
                phase2_dialague.SetActive(true);
            }
            else if (HP <= 0 && !phase1 && !life_regen)
            {
                time_Script.boss3_Scene = false;
                slider_animator.SetBool("Active", false);
                die.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public void Life_Regen()
    {
        phase1 = false;
        HP = maxHP;
        life_regen = true;
        slider_animator.SetBool("Active", true);
        animator.SetBool("Phase2", true);
    }
}
