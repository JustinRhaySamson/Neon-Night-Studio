using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSender : MonoBehaviour
{
    public EventReference sound;
    public bool isLooping;
    public bool isPlayingAuido;


    public bool playOnAwake = false;

    private EventInstance eventInstance;

    private void Awake()
    {
        if(playOnAwake == true)
        {
            LoopingAudio(0);
        }
    }

    public void LoopingAudio(int trueFalse)
    {

        if (!isPlayingAuido)
            return;

        if (trueFalse == 0)
        {
            if (!isLooping)
            {
                eventInstance = RuntimeManager.CreateInstance(sound);
                RuntimeManager.AttachInstanceToGameObject(eventInstance, gameObject);
                eventInstance.start();
                isLooping = true;
                Debug.Log(gameObject.name + " started looping audio");
            }
        }
        else
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            isLooping = false;
            Debug.Log(gameObject.name + " stopped looping audio");
        }
    }


    private void OnDestroy()
    {
        if (isLooping)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
    private void OnDisable()
    {
        if (isLooping)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

}

