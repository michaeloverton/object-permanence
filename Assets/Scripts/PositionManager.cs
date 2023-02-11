using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager Instance { get; private set; }
    [SerializeField] private bool on;
    // private List<Transform> positions = new List<Transform>();
    private List<TickMover> objects = new List<TickMover>();
    private Dictionary<TickMover, Transform> moverToTransform = new Dictionary<TickMover, Transform>();

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
        // positions.Add(mover.transform);
        moverToTransform[mover] = mover.transform;


        // registeredCount++;

        // Transform tform = positions[registeredCount];
        // mover.transform.position = tform.position;
        // moverToTransform[mover] = tform;
    }

    void ShuffleObjects(float t)
    {
        if(!on) return;
        // bool playerIsMoving = Manager.Instance.PlayerIsMoving();
        // if(!playerIsMoving) return;
        
        // Determine which objects to move.
        List<TickMover> objectsToMove = new List<TickMover>();
        List<Transform> availableTransforms = new List<Transform>();
        // List<Vector3> availablePositions = new List<Vector3>();
        foreach(TickMover tm in objects)
        {
            // if(Random.Range(0f, 1.0f) < tm.GetProbability() && playerIsMoving)
            if(Random.Range(0f, 1.0f) < tm.GetProbability())
            {
                Debug.Log("object can move: " + tm.gameObject.name);
                objectsToMove.Add(tm);
                Debug.Log("adding " + moverToTransform[tm].position.ToString());
                availableTransforms.Add(moverToTransform[tm]);
                // availablePositions.Add(moverToTransform[tm].position);
                moverToTransform.Remove(tm);
            }
        }

        //DEBUG LOGS
        foreach(Transform tr in availableTransforms)
        {
            Debug.Log(tr.position.ToString());
        }
        /// END DEBUGLOGS

        Debug.Log("objects to move: " + objectsToMove.Count);
        Debug.Log("available transforms: " + availableTransforms.Count);

        // shuffle list
        // for (int i = 0; i < availableTransforms.Count; i++) {
        //     Transform temp = availableTransforms[i];
        //     int randomIndex = Random.Range(i, availableTransforms.Count);
        //     availableTransforms[i] = availableTransforms[randomIndex];
        //     availableTransforms[randomIndex] = temp;
        // }

        // for(int i=0; i < objectsToMove.Count; i++)
        // {
        //     TickMover tm = objectsToMove[i];
        //     Transform newTransform = availableTransforms[i];
        //     tm.transform.position = newTransform.position;
        //     moverToTransform.Add(tm, newTransform);
        // }

        // Move objects.
        foreach(TickMover tm in objectsToMove)
        {
            Debug.Log(availableTransforms.Count);
            int newTransformIndex = Random.Range(0, availableTransforms.Count);
            Debug.Log("RANDOM INDEX: " + newTransformIndex);
            Transform newTransform = availableTransforms[newTransformIndex];
            tm.transform.position = newTransform.position;

            Debug.Log("moving " + tm.gameObject.name + " to " + newTransform.position.ToString());

            // moverToTransform[tm] = newTransform;
            moverToTransform.Add(tm, newTransform);
            // availableTransforms.Remove(newTransform);
            availableTransforms.RemoveAt(newTransformIndex);

            Debug.Log("transforms available after removal");
            foreach(Transform tr in availableTransforms)
            {
                Debug.Log(tr.position.ToString());
            }
        }

        Debug.Log("DONE://////////////////////////////////");
    }
}
