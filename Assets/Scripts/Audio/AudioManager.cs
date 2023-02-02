using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] FMODUnity.EventReference fireEvent;
    FMOD.Studio.EventInstance fireInstance;

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
        fireInstance = FMODUnity.RuntimeManager.CreateInstance(fireEvent);
        fireInstance.start();
    }
    
    public void FireOn()
    {
        Debug.Log("FIRE ON");
        fireInstance.setParameterByName("fireVolume", 1);
    }

    public void FireOff()
    {
        fireInstance.setParameterByName("fireVolume", 0);
    }
}
