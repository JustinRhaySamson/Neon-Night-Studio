using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Boss2_Phase2_Attacks : MonoBehaviour
{
    public GameObject Hitbox_Right;
    public GameObject Hitbox_Left;
    public Transform[] Inner_Spawners;
    public Transform[] Outer_Spawners;
    public Transform Left_Spawner;
    public Transform Right_Spawner;

    public GameObject Big_Laser;
    public GameObject Small_Laser;
    public GameObject Short_Laser;
    public EventReference sound;
    GameObject[] Lasers = new GameObject[6];

    bool weapon1 = false;
    bool weapon2 = false;

    public void Activate_Right()
    {
        Hitbox_Right.SetActive(true);
    }

    public void Activate_Left()
    {
        Hitbox_Left.SetActive(true);
    }

    public void Activate_Both()
    {
        Hitbox_Left.SetActive(true);
        Hitbox_Right.SetActive(true);
    }

    public void Deactivate_Right()
    {
        AudioManager.instance.PlaySoundOneShot(sound, Hitbox_Right);
        Hitbox_Right.SetActive(false);
    }

    public void Deactivate_Left()
    {
        AudioManager.instance.PlaySoundOneShot(sound, Hitbox_Left);
        Hitbox_Left.SetActive(false);
    }

    public void Deactivate_Both()
    {
        AudioManager.instance.PlaySoundOneShot(sound, Hitbox_Right);
        AudioManager.instance.PlaySoundOneShot(sound, Hitbox_Left);
        Hitbox_Right.SetActive(false);
        Hitbox_Left.SetActive(false);
    }

    public void Three_Small_Lasers()
    {
        for(int i = 0; i < Inner_Spawners.Length; i++)
        {
            Lasers[i] = null;
            GameObject laser = Instantiate(Small_Laser, Inner_Spawners[i].position + new Vector3(0,-.5f,0), 
                Inner_Spawners[i].rotation * Quaternion.Euler(180,-90,0));
            laser.transform.parent = Inner_Spawners[i];
            Lasers[i] = laser;
        }
    }

    public void Kill_Three_Small()
    {
        foreach(GameObject laser in Lasers)
        {
            Animator animator = laser.GetComponent<Animator>();
            animator.SetBool("Die", true);
        }
    }

    public void Three_Big_Lasers()
    {
        for (int i = 0; i < Inner_Spawners.Length; i++)
        {
            Lasers[i] = null;
            GameObject laser = Instantiate(Big_Laser, Inner_Spawners[i].position + new Vector3(0, -.5f, 0),
                Inner_Spawners[i].rotation * Quaternion.Euler(180, -90, 0));
            laser.transform.parent = Inner_Spawners[i];
            Lasers[i] = laser;
        }
    }

    public void Three_Back_Lasers()
    {
        for (int i = 0; i < Inner_Spawners.Length; i++)
        {
            Lasers[i] = null;
            GameObject laser = Instantiate(Big_Laser, Outer_Spawners[i].position + new Vector3(0, -.5f, 0),
                Outer_Spawners[i].rotation * Quaternion.Euler(0, -100, 0));
            laser.transform.parent = Outer_Spawners[i];
            Lasers[i] = laser;
        }
    }

    public void Six_Lasers()
    {
        for (int i = 0; i < Lasers.Length; i++)
        {
            Lasers[i] = null;
            GameObject laser = Instantiate(Big_Laser, Left_Spawner.position,
                Quaternion.Euler(0, i * 360 / 6, 90));
            //laser.transform.parent = Outer_Spawners[i];
            Lasers[i] = laser;
        }
    }

    public void Short_Laser_Spawn()
    {
        for (int i = 0; i < Lasers.Length; i++)
        {
            Lasers[i] = null;
        }
        GameObject laser = Instantiate(Short_Laser, Right_Spawner.position + new Vector3(0, -.5f, 0),
            Right_Spawner.rotation * Quaternion.Euler(180, -90, 0));
        laser.transform.parent = Right_Spawner;
        Lasers[0] = laser;
    }

    public void Store_Hitboxes()
    {
        weapon1 = Hitbox_Left.activeInHierarchy;
        weapon2 = Hitbox_Right.activeInHierarchy;
        Hitbox_Left.SetActive(false);
        Hitbox_Right.SetActive(false);
    }

    public void Restore_Hitboxes()
    {
        Hitbox_Left.SetActive(weapon1);
        Hitbox_Right.SetActive(weapon2);
    }
}
