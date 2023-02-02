using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    void Start()
    {
        PauseManager.Instance.OnPausePressed += onPaused;
    }

    void onPaused(bool val)
    {
        pauseScreen.SetActive(val);
    }
}
