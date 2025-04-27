using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    GameObject[] Lasers = new GameObject[3];

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
        Hitbox_Right.SetActive(false);
    }

    public void Deactivate_Left()
    {
        Hitbox_Left.SetActive(false);
    }

    public void Deactivate_Both()
    {
        Hitbox_Right.SetActive(false);
        Hitbox_Left.SetActive(false);
    }

    public void Three_Small_Lasers()
    {
        for(int i = 0; i < Inner_Spawners.Length; i++)
        {
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
}
