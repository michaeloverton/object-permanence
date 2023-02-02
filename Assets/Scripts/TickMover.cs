using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickMover : MonoBehaviour
{
    [SerializeField] float maxProbability = 1f;
    float currentProbability;

    // Start is called before the first frame update
    void Start()
    {
        currentProbability = 0;

        PositionManager.Instance.RegisterObject(this);
    }

    void Update()
    {
        currentProbability = maxProbability * Mathf.Pow(TimeManager.Instance.GetTimeUsedRatio(), 2);
    }

    public float GetProbability()
    {
        return currentProbability;
    }
}
