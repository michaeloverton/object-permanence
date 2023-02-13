using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEventListener : MonoBehaviour
{
    [SerializeField] List<GameObject> screens;
    [SerializeField] float screenShowTime = 2.0f;
    bool screenIsActive;
    float screenTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.OnScreenEvent += ShowScreen;
    }

    void ShowScreen(int index)
    {
        screens[index].SetActive(true);
        screenIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(screenIsActive)
        {
            screenTimer += Time.deltaTime;

            // If we have shown screen for enough time, disable all screens and reset timer.
            if(screenTimer > screenShowTime)
            {
                foreach(GameObject s in screens)
                {
                    s.SetActive(false);
                }

                screenTimer = 0;
                screenIsActive = false;
                Manager.Instance.FreezePlayer(false);
                AudioManager.Instance.FireOff();
            }
        }
    }
}
