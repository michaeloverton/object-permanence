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
        currentTime = Timer.Instance.GetMaxTime();
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.SetText(currentTime.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.SetText(currentTime.ToString("N3"));
    }
}
