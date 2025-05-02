using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuiscAmbienceSender : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeMuiscTrack(string MusicTrack)
    {
        AudioManager.instance.ChangeMusicTrackParameter(MusicTrack);
    }

    public void ChangeMuiscMode(string MuiscMode)
    {
        AudioManager.instance.ChangeMusicMode(MuiscMode);
    }

}
