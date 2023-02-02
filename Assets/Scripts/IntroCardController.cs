using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCardController : MonoBehaviour
{
    [SerializeField] float startMusicTime = 1f;
    float currentTime = 0f;
    bool playingMusic = false;

    // Update is called once per frame
    void Update()
    {
        if(!playingMusic)
        {   
            currentTime += Time.deltaTime;
            if(currentTime > startMusicTime)
            {
                Manager.Instance.FreezePlayer(false);

                if(!MusicManager.Instance.IsPlaying())
                {
                    MusicManager.Instance.PlayMusic();
                    playingMusic = true;
                } 
            }
        }
        
    }
}
