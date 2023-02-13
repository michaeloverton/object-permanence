using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyStart : MonoBehaviour
{
    [SerializeField] List<GameObject> toyGroups;

    // Start is called before the first frame update
    void Start()
    {
        // Disable all controllers initially just in case.
        foreach(GameObject c in toyGroups)
        {
            c.SetActive(false);
        }

        toyGroups[Random.Range(0, toyGroups.Count)].SetActive(true);
    }
}
