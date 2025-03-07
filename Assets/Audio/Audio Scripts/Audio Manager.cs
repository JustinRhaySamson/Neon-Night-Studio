using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
// PLAY ONESHOT
  public void PlaySoundOneShot (EventReference fmodEvent, GameObject target)
  {
	FMODUnity.RuntimeManager.PlayOneShotAttached(fmodEvent, target);
  }

// CHANGE MUSIC (might not even need)
  public void ChangeMusicParameter(string musicParameter)
  {
	  Debug.Log("changing music to "musicParameter);
	  RuntimeManager.StudioSystem.setParameterByName("Music Parameter", musicParameter);
  }

}
