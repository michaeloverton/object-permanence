using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBreathe : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.Log((0.87f + 0.1f * Mathf.Sin(Time.time)));
        float factor = (0.87f + 0.1f * Mathf.Sin(Time.time));
        Debug.Log(transform.localScale);

        transform.localScale = new Vector3(
            factor,
            factor,
            factor
        );
    }
}
