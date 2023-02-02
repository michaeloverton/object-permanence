using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager Instance { get; private set; }
    [SerializeField] List<Transform> positions;
    public List<TickMover> objects = new List<TickMover>();
    private Dictionary<TickMover, Transform> moverToTransform = new Dictionary<TickMover, Transform>();
    private int registeredCount = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TimeManager.Instance.OnTicked += ShuffleObjects;

        // Set initial positions.
        // for(int i=0; i < objects.Count; i++)
        // {
        //     GameObject g = objects[i].gameObject;
        //     Debug.Log(g.name);
        //     g.transform.position = positions[i].position;
        // }
    }

    // public List<Transform> GetPositions()
    // {
    //     return positions;
    // }

    // Registers the object and moves it into a designated position.
    public void RegisterObject(TickMover mover)
    {
        objects.Add(mover);
        registeredCount++;

        Transform tform = positions[registeredCount];
        mover.transform.position = tform.position;
        moverToTransform[mover] = tform;
    }

    void ShuffleObjects(float t)
    {
        bool playerIsMoving = Manager.Instance.PlayerIsMoving();
        if(!playerIsMoving) return;
        
        // Determine which objects to move.
        List<TickMover> objectsToMove = new List<TickMover>();
        List<Transform> availableTransforms = new List<Transform>();
        foreach(TickMover tm in objects)
        {
            if(Random.Range(0f, 1.0f) < tm.GetProbability() && playerIsMoving)
            {
                objectsToMove.Add(tm);
                availableTransforms.Add(moverToTransform[tm]);
                moverToTransform.Remove(tm);
            }
        }

        // Move objects.
        foreach(TickMover tm in objectsToMove)
        {
            Transform newTransform = availableTransforms[Random.Range(0, availableTransforms.Count)];
            tm.transform.position = newTransform.position;

            moverToTransform[tm] = newTransform;
            availableTransforms.Remove(newTransform);
        }
    }
}
