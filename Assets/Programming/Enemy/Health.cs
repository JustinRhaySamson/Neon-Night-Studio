using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int HP = 2;
    public bool shooter = true;
    public GameObject explosion;

    Time_Stop_Check_Melee time_stop_check_melee;
    Time_Stop_Check_Shooter time_stop_check_shooter;

    Room_Counter room_counter_script;

    MeshRenderer renderer;

    GameObject hit_vfx;
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        GameObject room_counter = GameObject.Find("Room_Counter");
        room_counter_script = room_counter.GetComponent<Room_Counter>();
        hit_vfx = transform.Find("HitEffect").gameObject;
    }

    public void Get_Hit()
    {
        renderer.material.color = Color.red;
        HP--;
        hit_vfx.SetActive(true);
        if (HP <= 0)
        {
            if (!shooter)
            {
                time_stop_check_melee = GetComponent<Time_Stop_Check_Melee>();
                time_stop_check_melee.Die();
            }
            else if (shooter)
            {
                time_stop_check_shooter = GetComponent<Time_Stop_Check_Shooter>();
                time_stop_check_shooter.Die();
            }
            GameObject explosion_object = Instantiate(explosion,gameObject.transform);
            explosion_object.transform.parent = null;
            explosion_object.transform.position = gameObject.transform.position;
            room_counter_script.EnemyKilled();
            Destroy(gameObject);
        }
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(.5f);
        renderer.material.color = Color.white;
        hit_vfx.SetActive(false);

    }
}
