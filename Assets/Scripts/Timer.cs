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

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        totalTimer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        if(tickTimer > tickRate) {
            Debug.Log("TICKED at " + totalTimer);
            tickTimer = 0;

            if(OnTicked != null) OnTicked(totalTimer);
        }
    }
}
