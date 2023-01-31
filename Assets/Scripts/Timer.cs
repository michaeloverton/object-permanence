using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public delegate void TickEvent(float val);
    public event TickEvent OnTicked;

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
