using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField] List<GameObject> controllers;

    // Start is called before the first frame update
    void Start()
    {
        // Disable all controllers initially just in case.
        foreach(GameObject c in controllers)
        {
            c.SetActive(false);
        }

        controllers[Random.Range(0, controllers.Count)].SetActive(true);
    }
}
