using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public Player_Controller controller;
    private void OnTriggerEnter(Collider other)
    {
        controller.Gravity_Not_Active();
    }

    private void OnTriggerExit(Collider other)
    {
        controller.Gravity_Active();
    }
}
