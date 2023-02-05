using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] FMODUnity.EventReference fireEvent;
    FMOD.Studio.EventInstance fireInstance;
    [SerializeField] FMODUnity.EventReference backgroundEvent;
    FMOD.Studio.EventInstance backgroundInstance;
    [SerializeField] FMODUnity.StudioEventEmitter backgroundEmitter;
    [SerializeField] [Range(0,1)] float initialBackgroundVolume;

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

        fireInstance = FMODUnity.RuntimeManager.CreateInstance(fireEvent);
        // fireInstance.start();
        // fireInstance.release();
    }

    void Start()
    {
        backgroundEmitter.Play();
    }

    void Update()
    {
        SetBackgroundVolume(TimeManager.Instance.GetTimeUsedRatio());
        FMODUnity.RuntimeManager.CoreSystem.update();
    }
    
    public void FireOn()
    {
        Debug.Log("FIRE ON");
        // fireInstance.setParameterByName("fireVolume", 1);
        // fireInstance.start();
    }

    public void FireOff()
    {
        // fireInstance.setParameterByName("fireVolume", 0);
        // fireInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void SetBackgroundVolume(float val)
    {
        float vol = initialBackgroundVolume + val*(1 - initialBackgroundVolume);
        backgroundEmitter.SetParameter("chaosVolume", vol);
    }
}
