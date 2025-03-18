using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public enum musicTrack
{
    None,
    Area1,
    Area2,
    Area3,
    Area4,
    Area5,
    Area6
}

public enum ambienceTrack
{
    None,
    Level1,
    Level2
}



public class AudioManager : MonoBehaviour
{
    // TURN ON!
    public static AudioManager instance;

    [Header("Music")]
    private EventInstance musicInstance;
    public List<EventReference> music;

    [Header("Ambience")]
    private EventInstance ambienceInstance;
    public List<EventReference> ambience;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("AUDIO MANAGER IS CREATED!");
            instance = this;
        }
        else
        {
            Debug.Log("AUDIO MANAGER IS DESTROYED!");
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        StartMusic(0);
        StartAmbience(0);
    }

    public void StartMusic(int SoundNumber)
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
       
        musicInstance = RuntimeManager.CreateInstance(music[SoundNumber]);
        musicInstance.start();
       
    }

    public void Stop()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        ambienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void StartAmbience(int SoundNumber)
    {
        ambienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);


        ambienceInstance = RuntimeManager.CreateInstance(ambience[SoundNumber]);
        ambienceInstance.start();
    }

    // PLAY ONESHOT
    public void PlaySoundOneShot (EventReference fmodEvent, GameObject target)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(fmodEvent, target);
    }

    // CHANGE MUSIC (might not even need)
    public void ChangeMusicParameter(string musicParameter)
    {
	    Debug.Log("changing music to "+musicParameter);
	    RuntimeManager.StudioSystem.setParameterByNameWithLabel("Music Parameter", musicParameter);
    }

    public void ChangeAmbienceParameter(string ambienceParameter)
    {
        Debug.Log("changing ambience to " + ambienceParameter);
        RuntimeManager.StudioSystem.setParameterByNameWithLabel("Music Parameter", ambienceParameter);
    }



}
