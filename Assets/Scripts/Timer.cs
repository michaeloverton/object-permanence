using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    
    // Events.
    public delegate void TickEvent(float val);
    public event TickEvent OnTicked;
    public delegate void ScreenEvent(int index);
    public event ScreenEvent OnScreenEvent;
    int screenEventIndex = 0;
    [SerializeField] float screenOneTime = 2f;
    [SerializeField] float screenTwoTime = 10f;

    // Timer vars.
    float totalTimer = 0f;
    float tickTimer = 0f;
    [SerializeField] float tickRate = 1f;

    [SerializeField] float maxTime = 60f;
    float timeLeft;
    float timeUsedRatio;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timeLeft = maxTime;
        timeUsedRatio = 0;
    }

    // Update is called once per frame
    void Update()
    {
        totalTimer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        if(tickTimer > tickRate) {
            tickTimer = 0;

            if(OnTicked != null) OnTicked(totalTimer);
        }

        // Time remaining calculations.
        timeLeft -= Time.deltaTime;
        timeUsedRatio = 1 - (timeLeft/maxTime);

        // Screen event calculations.
        if(totalTimer > screenOneTime && screenEventIndex == 0)
        {
            if(OnScreenEvent != null) OnScreenEvent(screenEventIndex);
            screenEventIndex++;
        }
        if(totalTimer > screenTwoTime && screenEventIndex == 1)
        {
            if(OnScreenEvent != null) OnScreenEvent(screenEventIndex);
            screenEventIndex++;
        }
    }

    public float GetMaxTime()
    {
        return maxTime;
    }

    public float GetTimeUsedRatio()
    {
        return timeUsedRatio;
    }
}
