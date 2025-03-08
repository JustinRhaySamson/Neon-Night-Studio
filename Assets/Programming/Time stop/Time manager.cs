using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Timemanager : MonoBehaviour
{
    public float time_amount = 0;
    public bool Time_Stopped = false;
    public bool cooldown = false;
    public bool doorBool = false;
    public bool boss1_scene = false;
    public bool boss2_Scene = false;

    public Time_Stop_Check_Shooter[] enemies_shooter;
    public Time_Stop_Check_Melee[] enemies_melee;
    public Basic_Bullet[] bullets;
    public Explosion_Script[] explosions;
    public Lightning_Script[] lightnings;
    public Lightning_Spawner[] lightning_spawns;
    public Tornado_Script[] tornado_scripts;
    

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
    Boss1_State_Manager boss1_State_Manager;
    float boss1_speed = 0;
    int boss1_force = 0;

    GameObject boss2;
    Animator boss2_animator;
    //Vortex_Projectiles vortex_Projectiles;
    Boss2_State_Manager boss2_State_Manager;
    float boss2_speed = 0;
    int boss2_force = 0;

    public float refill_timer = 0;

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
            slider_component.value = Time.time - slider_time2 + 3 * refill_timer;
            
            if (slider_component.value == slider_component.maxValue)
            {
                cooldown = false;
            }
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
                GameObject oni_Shockwave = explosions[i].transform.Find("Oni_Shockwave").gameObject; ;
                GameObject electricity = oni_Shockwave.transform.Find("Electricity").gameObject;
                GameObject indicator = oni_Shockwave.transform.Find("Indicator").gameObject;
                GameObject sparks = oni_Shockwave.transform.Find("Sparks").gameObject;
                ParticleSystem electricity_system = electricity.GetComponent<ParticleSystem>();
                ParticleSystem indicator_system = indicator.GetComponent<ParticleSystem>();
                ParticleSystem sparks_system = sparks.GetComponent<ParticleSystem>();
                electricity_system.Pause(true);
                indicator_system.Pause(true);
                sparks_system.Pause(true);
            }
            foreach(Lightning_Script lightning in lightnings)
            {
                lightning.Time_Stop_Pause();
            }
            foreach(Lightning_Spawner spawner in lightning_spawns)
            {
                spawner.Time_Stop();
            }
            foreach(Tornado_Script tornado in tornado_scripts)
            {
                tornado.Time_Stop();
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
                boss1_force = boss1_State_Manager.force;
                boss1_State_Manager.force = 0;
                Rigidbody rb = boss1.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
            }
            if (boss2_Scene)
            {
                boss2_speed = boss2_animator.GetFloat("Speed");
                boss2_animator.SetFloat("Speed", 0);
                Look_At boss2_look = boss2.gameObject.GetComponent<Look_At>();
                boss2_look.enabled = false;
                boss2_force = boss2_State_Manager.force;
                boss2_State_Manager.force = 0;
                Rigidbody rb = boss2.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
            }
            
            StartCoroutine(ResetTime(time_amount));
            //StartCoroutine(Cooldown_Timer());
        } 
    }

    IEnumerator ResetTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time_Stopped = false;
        refill_timer = 0;
        slider_component.maxValue = 20;
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
            GameObject oni_Shockwave = explosions[i].transform.Find("Oni_Shockwave").gameObject; ;
            GameObject electricity = oni_Shockwave.transform.Find("Electricity").gameObject;
            GameObject indicator = oni_Shockwave.transform.Find("Indicator").gameObject;
            GameObject sparks = oni_Shockwave.transform.Find("Sparks").gameObject;
            ParticleSystem electricity_system = electricity.GetComponent<ParticleSystem>();
            ParticleSystem indicator_system = indicator.GetComponent<ParticleSystem>();
            ParticleSystem sparks_system = sparks.GetComponent<ParticleSystem>();
            electricity_system.Play(true);
            indicator_system.Play(true);
            sparks_system.Play(true);
        }
        foreach (Lightning_Script lightning in lightnings)
        {
            lightning.Time_Stop_Restart();
        }
        foreach (Lightning_Spawner spawner in lightning_spawns)
        {
            spawner.Time_Reset();
        }
        foreach (Tornado_Script tornado in tornado_scripts)
        {
            tornado.Time_Reset();
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
            boss1_State_Manager.force = boss1_force;
        }
        if (boss2_Scene)
        {
            boss2_animator.SetFloat("Speed", boss2_speed);
            Look_At boss2_look = boss2.gameObject.GetComponent<Look_At>();
            boss2_look.enabled = true;
            boss2_State_Manager.force = boss2_force;
        }
    }

    IEnumerator Cooldown_Timer()
    {
        yield return new WaitForSeconds(23.1f);
        cooldown = false;
    }

    public void Activate_Boss1(GameObject boss)
    {
        boss1_scene = true;
        boss1 = boss;
        boss1_animator = boss1.GetComponent<Animator>();
        vortex_Projectiles = GameObject.Find("Vortex Bullet Spawner").GetComponent<Vortex_Projectiles>();
        boss1_State_Manager = boss1.GetComponent<Boss1_State_Manager>();
    }

    public void Activate_Boss2(GameObject boss)
    {
        boss2_Scene = true;
        boss2 = boss;
        boss2_animator = boss2.GetComponent<Animator>();
        boss2_State_Manager = boss2.GetComponent<Boss2_State_Manager>();
    }
}
