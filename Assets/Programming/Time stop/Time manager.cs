using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timemanager : MonoBehaviour
{
    public float time_amount = 0;
    public bool Time_Stopped = false;
    public bool cooldown = false;
    public bool doorBool = false;
    public bool boss1_scene = false;

    public Time_Stop_Check_Shooter[] enemies_shooter;
    public Time_Stop_Check_Melee[] enemies_melee;
    public Basic_Bullet[] bullets;
    public Explosion_Script[] explosions;
    

    bool LB_Press = false;
    bool RB_Press = false;

    GameObject slider;
    Slider slider_component;
    float slider_time;
    float slider_time2;

    GameObject door;
    Animator door_animator;
    GameObject door_stopper;

    GameObject player;
    MeshTrail trail_script;

    GameObject boss1;
    Animator boss1_animator;
    Vortex_Projectiles vortex_Projectiles;
    float boss1_speed = 0;

    void Start()
    {
        slider = GameObject.Find("Slider_new");
        slider_component = slider.GetComponent<Slider>();
        player = GameObject.Find("Player");
        trail_script = player.GetComponent<MeshTrail>();
        if (doorBool)
        {
            door = GameObject.Find("TimeStop_Door");
            door_animator = door.GetComponent<Animator>();
            door_stopper = GameObject.Find("Door_Stopper");
        }
        if (boss1_scene)
        {
            boss1 = GameObject.Find("YOKAI_BOSS_ONI");
            boss1_animator = boss1.GetComponent<Animator>();
            vortex_Projectiles = GameObject.Find("Vortex Bullet Spawner").GetComponent<Vortex_Projectiles>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time_Stopped)
        {
            slider_component.value = 2.9f - (Time.time - slider_time);
        }
        if(!Time_Stopped && cooldown)
        {
            slider_component.value = Time.time - slider_time2;
        }
    }

    public void LB_Check()
    {
        LB_Press = true;
        Button_Combo();
        StartCoroutine(LB_Time());
    }

    IEnumerator LB_Time()
    {
        yield return new WaitForSeconds(.1f);
        LB_Press=false;
    }

    public void RB_Check()
    {
        RB_Press = true;
        Button_Combo();
        StartCoroutine(RB_Time());
    }

    IEnumerator RB_Time()
    {
        yield return new WaitForSeconds(.1f);
        RB_Press = false;
    }

    void Button_Combo()
    {
        if (LB_Press && RB_Press)
        {
            ChangeTime();
        }
    }

    public void ChangeTime()
    {
        if (!cooldown && slider_component.value == slider_component.maxValue)
        {
            trail_script.Start_Trail();
            cooldown = true;
            Time_Stopped = true;
            slider_component.maxValue = 2.9f;
            slider_component.value = 2.9f;
            slider_time = Time.time;
            for (int i = 0; i < enemies_shooter.Length; i++)
            {
                enemies_shooter[i].StopEnemy();
            }
            for (int i = 0; i < enemies_melee.Length; i++)
            {
                enemies_melee[i].StopEnemy();
            }
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].StopBullet();
            }
            for (int i = 0; i < explosions.Length; i++)
            {
                explosions[i].Stop_Explosion();
            }
            if (doorBool)
            {
                door_animator.SetFloat("Speed", 0);
                door_stopper.SetActive(false);
            }
            if(boss1_scene)
            {
                boss1_speed = boss1_animator.GetFloat("Speed");
                vortex_Projectiles.StopAllCoroutines();
                boss1_animator.SetFloat("Speed", 0);
                Look_At boss1_look = boss1.gameObject.GetComponent<Look_At>();
                boss1_look.enabled = false;
            }
            StartCoroutine(ResetTime(time_amount));
            StartCoroutine(Cooldown_Timer());
        } 
    }

    IEnumerator ResetTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time_Stopped = false;
        slider_component.maxValue = 4;
        slider_time2 = Time.time;
        for (int i = 0; i < enemies_shooter.Length; i++)
        {
            enemies_shooter[i].RestartEnemy();
        }
        for (int i = 0; i < enemies_melee.Length; i++)
        {
            enemies_melee[i].RestartEnemy();
        }
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].RestartBullet();
        }
        for (int i = 0; i < explosions.Length; i++)
        {
            explosions[i].Restart_Explosion();
        }
        if (doorBool)
        {
            door_animator.SetFloat("Speed", 1);
            door_stopper.SetActive(true);
        }
        if (boss1_scene)
        {
            vortex_Projectiles.Restart_Shooting();
            boss1_animator.SetFloat("Speed", boss1_speed);
            Look_At boss1_look = boss1.gameObject.GetComponent<Look_At>();
            boss1_look.enabled = true;
        }
    }

    IEnumerator Cooldown_Timer()
    {
        yield return new WaitForSeconds(7.1f);
        cooldown = false;
    }
}
