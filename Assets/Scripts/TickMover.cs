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
        Timer.Instance.OnTicked += MoveObject;
        currentProbability = 0;
    }

    void Update()
    {
        currentProbability = maxProbability * Mathf.Pow(Timer.Instance.GetTimeUsedRatio(), 2);
    }

    private void MoveObject(float time)
    {
        if(Random.Range(0f, 1.0f) < currentProbability && Manager.Instance.PlayerIsMoving())
        {
            List<Transform> positions = Positions.Instance.GetPositions();
            transform.position = positions[Random.Range(0, positions.Count)].position;
        }
    }
}
