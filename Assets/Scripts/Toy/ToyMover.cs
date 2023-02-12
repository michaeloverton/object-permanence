using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMover : MonoBehaviour
{
    [SerializeField] float amount = 0.005f;
    [SerializeField] float offset = 0.05f;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(
            transform.localPosition.x + Mathf.Sin(Time.time + offset) * amount * Time.deltaTime,
            transform.localPosition.y + Mathf.Sin(Time.time + offset) * amount * Time.deltaTime,
            transform.localPosition.z);
    }
}
