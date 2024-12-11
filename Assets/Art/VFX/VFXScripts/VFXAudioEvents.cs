using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAudioEvents : MonoBehaviour
{
    public GameObject VFX;

    void Activate()
    {
        VFX.SetActive(true);
        Debug.Log("VFX activated");
    }

    void Deactivate()
    {
        VFX.SetActive(false);
        Debug.Log("VFX deactivated");
    }
}
