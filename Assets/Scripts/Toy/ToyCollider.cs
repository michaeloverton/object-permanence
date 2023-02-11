using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToyCollider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] LayerMask toyLayer;
    [SerializeField] float rayDistance = 1.0f;
    [SerializeField] List<string> prefixes;
    [SerializeField] float changeTextTime = .1f;
    float elapsedTime = 0;
    int currentPrefixIndex = 0;

    void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hitInfo, rayDistance, toyLayer))
        {
            GameObject toyObject = hitInfo.collider.gameObject;
            text.enabled = true;

            // text.SetText("PICK UP " + toyObject.name);

            if(elapsedTime > changeTextTime)
            {
                currentPrefixIndex = (currentPrefixIndex + 1) % prefixes.Count;
                elapsedTime = 0;
            }

            text.SetText(prefixes[currentPrefixIndex] + " " + toyObject.name);


            if(Input.GetKey(KeyCode.F))
            {
                toyObject.GetComponent<ToyEnabler>().Enable();
            }

            elapsedTime += Time.deltaTime;
        }
        else
        {
            text.enabled = false;
            elapsedTime = 0;
        }
    }
}
