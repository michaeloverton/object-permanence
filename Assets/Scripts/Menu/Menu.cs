using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class Menu : MonoBehaviour
{
    [Header("Title Screen")]
    // Only for use in start screen.
    [SerializeField] GameObject blackPanel;
    [SerializeField] float blackTime = 1.5f;
    [SerializeField] FMODUnity.StudioEventEmitter music;
    [SerializeField] FMODUnity.StudioEventEmitter fire;

    [Header("Main Scene")]
    [SerializeField] GameObject blackEndPanel;
    [SerializeField] float blackEndTime = 1.5f;
    // [SerializeField] FMODUnity.StudioEventEmitter mainMusic;
    // [SerializeField] FMODUnity.StudioEventEmitter chaos;

    // void Start()
    // {
    //     Manager m = GameObject.FindObjectOfType<Manager>();
    //     Destroy(m);
    //     AudioManager am = GameObject.FindObjectOfType<AudioManager>();
    //     Destroy(am);
    //     MusicManager mm = GameObject.FindObjectOfType<MusicManager>();
    //     Destroy(mm);
    // }
    
    public void Remember()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        blackPanel.SetActive(true);
        music.Stop();
        fire.Stop();

        yield return new WaitForSeconds(blackTime);
        SceneManager.LoadScene("Main");
    }

    public void Forget()
    {
        StartCoroutine(LoadTitleScene());
    }

    IEnumerator LoadTitleScene()
    {
        blackEndPanel.SetActive(true);
        MusicManager.Instance.StopMusic();
        AudioManager.Instance.StopBackground();
        // mainMusic.Stop();
        // chaos.Stop();
        // AudioManager am = GameObject.FindObjectOfType<AudioManager>();
        // Destroy(am.gameObject);
        // MusicManager mm = GameObject.FindObjectOfType<MusicManager>();
        // Destroy(mm.gameObject);

        yield return new WaitForSeconds(blackEndTime);

        Manager m = GameObject.FindObjectOfType<Manager>();
        Destroy(m.gameObject);
        AudioManager am = GameObject.FindObjectOfType<AudioManager>();
        Destroy(am.gameObject);
        MusicManager mm = GameObject.FindObjectOfType<MusicManager>();
        Destroy(mm.gameObject);

        SceneManager.LoadScene("Title");
    }
}
