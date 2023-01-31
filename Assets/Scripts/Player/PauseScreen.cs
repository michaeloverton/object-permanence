using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] PauseManager pauseManager;
    [SerializeField] GameObject pauseScreen;

    void Start()
    {
        pauseManager.OnPausePressed += onPaused;
    }

    void onPaused(bool val)
    {
        pauseScreen.SetActive(val);
    }
}
