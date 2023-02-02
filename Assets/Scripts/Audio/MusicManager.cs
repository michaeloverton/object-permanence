using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    FMODUnity.StudioEventEmitter musicEmitter;
    

    void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        musicEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    public void PlayMusic()
    {
        musicEmitter.Play();
    }

    public bool IsPlaying()
    {
        return musicEmitter.IsPlaying();
    }
}