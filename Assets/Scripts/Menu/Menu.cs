using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class Menu : MonoBehaviour
{
    // Only for use in start screen.
    [SerializeField] GameObject blackPanel;
    [SerializeField] float blackTime = 1.5f;
    [SerializeField] FMODUnity.StudioEventEmitter music;
    [SerializeField] FMODUnity.StudioEventEmitter fire;
    
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
        blackPanel.SetActive(true);
        music.Stop();
        fire.Stop();

        yield return new WaitForSeconds(blackTime);
        SceneManager.LoadScene("Title");
    }
}
