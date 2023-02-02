using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    FMODUnity.StudioEventEmitter musicEmitter;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        musicEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    public void PlayMusic()
    {
        musicEmitter.Play();
    }

    // void PauseMusic()
    // {
    //     musicEmitter.set
    // }
}
