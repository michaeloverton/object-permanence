using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFootstepTypeTrigger : MonoBehaviour
{
    [SerializeField] private AudioManagerEXAMPLE audioManager;
    [SerializeField] private int footstepType;

    void OnTriggerEnter(Collider other)
    {
        audioManager.SetStepSurface(footstepType);
    }
}
