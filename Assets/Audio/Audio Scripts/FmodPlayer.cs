using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodPlayer : MonoBehaviour
{
    public GameObject Target;
    public void PlaySound (string FMODEvent)
    {
        if (Target == null)
        {
            Target = gameObject;
        }

        FMODUnity.RuntimeManager.PlayOneShotAttached(FMODEvent, Target);
    }

    public void PlaySound2 (string FMODEvent)
    {
        if (Target == null)
        {
            Target = gameObject;
        }

        FMODUnity.RuntimeManager.PlayOneShotAttached(FMODEvent, Target);
    }
}
