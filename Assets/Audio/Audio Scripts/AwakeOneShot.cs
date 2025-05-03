using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeOneShot : MonoBehaviour
{
    public EventReference sound;

    // Start is called before the first frame update
    void Awake()
    {
        AudioManager.instance.PlaySoundOneShot(sound, gameObject);
    }                    
}
