using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSender : MonoBehaviour
{
    public List<EventReference> sound;

    public void PlayOneShot(int soundNumber)
    {
        AudioManager.instance.PlaySoundOneShot(sound[soundNumber], gameObject);
    }

    public void DeathSoundMusic()
    {
        AudioManager.instance.Stop();
    }
}

