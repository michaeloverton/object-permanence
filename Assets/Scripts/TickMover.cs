using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickMover : MonoBehaviour
{
    [SerializeField] float probability = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Timer.Instance.OnTicked += MoveObject;
    }

    private void MoveObject(float time)
    {
        if(Random.Range(0f, 1.0f) < probability && Manager.Instance.PlayerIsMoving())
        {
            Debug.Log("moving object");
            List<Transform> positions = Positions.Instance.GetPositions();
            transform.position = positions[Random.Range(0, positions.Count)].position;
        }
    }
}
