using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class TextTimer : MonoBehaviour
{
    float currentTime;
    TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = TimeManager.Instance.GetMaxTime();
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.SetText(currentTime.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0) currentTime = 0;
        timerText.SetText(currentTime.ToString("N3"));
    }
}
