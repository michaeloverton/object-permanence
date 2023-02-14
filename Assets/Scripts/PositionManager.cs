using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager Instance { get; private set; }
    [SerializeField] private bool on;
    private List<TickMover> objects = new List<TickMover>();
    private Dictionary<TickMover, Vector3> moverToPosition = new Dictionary<TickMover, Vector3>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TimeManager.Instance.OnTicked += ShuffleObjects;
    }

    // Registers the object and moves it into a designated position.
    public void RegisterObject(TickMover mover)
    {
        objects.Add(mover);
        moverToPosition[mover] = mover.transform.position;
    }

    void ShuffleObjects(float t)
    {
        if(!on) return;
        bool playerIsMoving = Manager.Instance.PlayerIsMoving();
        if(!playerIsMoving) return;

        // Determine which objects to move.
        List<TickMover> objectsToMove = new List<TickMover>();
        List<Vector3> availablePositions = new List<Vector3>();
        foreach(TickMover tm in objects)
        {
            if(Random.Range(0f, 1.0f) < tm.GetProbability())
            // if(Random.Range(0f, 1.0f) < tm.GetProbability())
            {
                objectsToMove.Add(tm);
                availablePositions.Add(moverToPosition[tm]);
                moverToPosition.Remove(tm);
            }
        }

        // Move objects.
        foreach(TickMover tm in objectsToMove)
        {
            int newTransformIndex = Random.Range(0, availablePositions.Count);
            Vector3 newTransform = new Vector3(
                availablePositions[newTransformIndex].x, 
                availablePositions[newTransformIndex].y, 
                availablePositions[newTransformIndex].z);

            tm.transform.position = newTransform;
            moverToPosition.Add(tm, newTransform);
            availablePositions.RemoveAt(newTransformIndex);
        }
    }
}
