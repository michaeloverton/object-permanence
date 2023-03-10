using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    
    // Events.
    public delegate void TickEvent(float val);
    public event TickEvent OnTicked;
    public delegate void ScreenEvent(int index);
    public event ScreenEvent OnScreenEvent;
    int screenEventIndex = 0;
    [SerializeField] bool playScreenEvents = true;
    [SerializeField] float screenOneTime = 2f;
    [SerializeField] float screenTwoTime = 10f;
    [SerializeField] float screenThreeTime = 20f;
    
    // Timer vars.
    float totalTimer = 0f;
    float tickTimer = 0f;
    [SerializeField] float tickRate = 1f;

    [SerializeField] float maxTime = 60f;
    float timeLeft;
    float timeUsedRatio;
    [SerializeField] GameObject endScreen;
    [SerializeField] float endScreenTime = 3.0f;
    bool stopped = false;

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
        if(stopped) return;

        totalTimer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        if(tickTimer > tickRate) {
            tickTimer = 0;

            if(OnTicked != null) OnTicked(totalTimer);
        }

        // Time remaining calculations.
        timeLeft -= Time.deltaTime;
        timeUsedRatio = 1 - (timeLeft/maxTime);

        if(timeUsedRatio >= 1f) {
            StartCoroutine(ShowEndScreen());
            return;
        }

        // Screen event calculations.
        if(playScreenEvents)
        {
            if(totalTimer > screenOneTime && screenEventIndex == 0)
            {
                if(OnScreenEvent != null) OnScreenEvent(screenEventIndex);
                screenEventIndex++;
                Manager.Instance.FreezePlayer(true);
                AudioManager.Instance.FireOn();
            }
            if(totalTimer > screenTwoTime && screenEventIndex == 1)
            {
                if(OnScreenEvent != null) OnScreenEvent(screenEventIndex);
                screenEventIndex++;
                Manager.Instance.FreezePlayer(true);
                AudioManager.Instance.FireOn();
            }
            if(totalTimer > screenThreeTime && screenEventIndex == 2)
            {
                if(OnScreenEvent != null) OnScreenEvent(screenEventIndex);
                screenEventIndex++;
                Manager.Instance.FreezePlayer(true);
                AudioManager.Instance.FireOn();
            }
        }
    }

    public float GetMaxTime()
    {
        return maxTime;
    }

    public float GetTimeUsedRatio()
    {
        return Mathf.Clamp01(timeUsedRatio);
    }

    IEnumerator ShowEndScreen()
    {
        endScreen.SetActive(true);

        yield return new WaitForSeconds(endScreenTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Stop()
    {
        stopped = true;
    }
}
