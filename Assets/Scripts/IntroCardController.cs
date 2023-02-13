using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCardController : MonoBehaviour
{
    [SerializeField] float startMusicTime = 1f;

    void Start()
    {
        StartCoroutine(ShowTitle());
    }

    IEnumerator ShowTitle()
    {
        AudioManager.Instance.FireOn();

        yield return new WaitForSeconds(startMusicTime);

        Manager.Instance.FreezePlayer(false);
        AudioManager.Instance.FireOff();
        if(!MusicManager.Instance.IsPlaying())  MusicManager.Instance.PlayMusic();
    }
}
