using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager Instance { get; private set; }
    [SerializeField] private bool on;
    // private List<Transform> positions = new List<Transform>();
    private List<TickMover> objects = new List<TickMover>();
    // private Dictionary<TickMover, Transform> moverToTransform = new Dictionary<TickMover, Transform>();
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
        // moverToTransform[mover] = mover.transform;
        moverToPosition[mover] = mover.transform.position;
    }

    void ShuffleObjects(float t)
    {
        if(!on) return;
        // bool playerIsMoving = Manager.Instance.PlayerIsMoving();
        // if(!playerIsMoving) return;

        /*
        
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
            Debug.Log("transforms count: " + availableTransforms.Count);
            int newTransformIndex = Random.Range(0, availableTransforms.Count);
            Debug.Log("RANDOM INDEX: " + newTransformIndex);
            Transform newTransform = availableTransforms[newTransformIndex];
            tm.transform.position = newTransform.position;

            Debug.Log("moving " + tm.gameObject.name + " to " + newTransform.position.ToString());

            // moverToTransform[tm] = newTransform;
            moverToTransform.Add(tm, newTransform);
            // availableTransforms.Remove(newTransform);

            // availableTransforms.RemoveAt(newTransformIndex);

            Debug.Log("transforms available after removal");
            foreach(Transform tr in availableTransforms)
            {
                Debug.Log(tr.position.ToString());
            }
        }

        Debug.Log("DONE://////////////////////////////////");

        */

        // Determine which objects to move.
        List<TickMover> objectsToMove = new List<TickMover>();
        List<Vector3> availablePositions = new List<Vector3>();
        // List<Vector3> availablePositions = new List<Vector3>();
        foreach(TickMover tm in objects)
        {
            // if(Random.Range(0f, 1.0f) < tm.GetProbability() && playerIsMoving)
            if(Random.Range(0f, 1.0f) < tm.GetProbability())
            {
                Debug.Log("object can move: " + tm.gameObject.name);
                objectsToMove.Add(tm);
                Debug.Log("adding " + moverToPosition[tm].ToString());
                availablePositions.Add(moverToPosition[tm]);
                // availablePositions.Add(moverToTransform[tm].position);
                moverToPosition.Remove(tm);
            }
        }

        //DEBUG LOGS
        foreach(Vector3 tr in availablePositions)
        {
            Debug.Log(tr.ToString());
        }
        /// END DEBUGLOGS

        Debug.Log("objects to move: " + objectsToMove.Count);
        Debug.Log("available transforms: " + availablePositions.Count);

        // Move objects.
        foreach(TickMover tm in objectsToMove)
        {
            Debug.Log("transforms count: " + availablePositions.Count);
            int newTransformIndex = Random.Range(0, availablePositions.Count);
            Debug.Log("RANDOM INDEX: " + newTransformIndex);
            Vector3 newTransform = new Vector3(
                availablePositions[newTransformIndex].x, 
                availablePositions[newTransformIndex].y, 
                availablePositions[newTransformIndex].z);

            tm.transform.position = newTransform;

            Debug.Log("moving " + tm.gameObject.name + " to " + newTransform.ToString());

            // moverToTransform[tm] = newTransform;
            moverToPosition.Add(tm, newTransform);
            // availableTransforms.Remove(newTransform);

            availablePositions.RemoveAt(newTransformIndex);

            Debug.Log("transforms available after removal");
            foreach(Vector3 tr in availablePositions)
            {
                Debug.Log(tr.ToString());
            }
        }

        Debug.Log("DONE://////////////////////////////////");
    }
}
