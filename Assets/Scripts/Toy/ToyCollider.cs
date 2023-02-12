using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToyCollider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectText;
    [SerializeField] TextMeshProUGUI prefixText;
    [SerializeField] LayerMask toyLayer;
    [SerializeField] float rayDistance = 1.0f;
    [SerializeField] List<string> prefixes;
    [SerializeField] float baseTextTime = .1f;
    [SerializeField] float timeIncrement = 0.01f;
    float currentTextTime;
    float elapsedTime = 0;
    int currentPrefixIndex = 0;

    void Start()
    {
        currentTextTime = baseTextTime;
    }

    void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hitInfo, rayDistance, toyLayer))
        {
            GameObject toyObject = hitInfo.collider.gameObject;
            objectText.enabled = true;
            prefixText.enabled = true;

            if(elapsedTime > currentTextTime)
            {
                currentPrefixIndex = (currentPrefixIndex + 1) % prefixes.Count;
                elapsedTime = 0;

                if(currentTextTime > timeIncrement)
                {
                    currentTextTime -= timeIncrement;
                }
            }

            prefixText.SetText(prefixes[currentPrefixIndex]);
            objectText.SetText(toyObject.name);


            if(Input.GetKey(KeyCode.F))
            {
                toyObject.GetComponent<ToyEnabler>().Enable();
            }

            elapsedTime += Time.deltaTime;
        }
        else
        {
            objectText.enabled = false;
            prefixText.enabled = false;
            elapsedTime = 0;
            currentTextTime = baseTextTime;
        }
    }
}
