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
    [SerializeField] FMODUnity.EventReference tinnitusEvent;
    FMOD.Studio.EventInstance tinnitusInstance;
    float tinMaxTime;

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
        fireInstance.start();
        tinMaxTime = TimeManager.Instance.GetMaxTime() * 0.8f;
        tinnitusInstance = FMODUnity.RuntimeManager.CreateInstance(tinnitusEvent);
        tinnitusInstance.start();
    }

    void Start()
    {
        backgroundEmitter.Play();
    }

    void Update()
    {
        SetBackgroundVolume(TimeManager.Instance.GetTimeUsedRatio());
        SetTinnitusVolume();
    }
    
    public void FireOn()
    {
        fireInstance.setParameterByName("fireVolume", 1);
    }

    public void FireOff()
    {
        fireInstance.setParameterByName("fireVolume", 0);
    }

    public void StopBackground()
    {
        backgroundEmitter.Stop();
        tinnitusInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetBackgroundVolume(float val)
    {
        float vol = initialBackgroundVolume + val*(1 - initialBackgroundVolume);
        backgroundEmitter.SetParameter("chaosVolume", vol);
    }

    public void SetTinnitusVolume()
    {
        float val = Mathf.Clamp01(Time.time / tinMaxTime);
        tinnitusInstance.setParameterByName("tinVolume", val);
    }
}
