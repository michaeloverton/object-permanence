using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureShifter : MonoBehaviour
{
    [SerializeField] List<Material> images;
    [SerializeField] float changeTime = 0.2f;
    float elapsedTime = 0;
    MeshRenderer mr;
    int currentImageIndex = 0;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        currentImageIndex = Random.Range(0, images.Count);
        mr.material = images[currentImageIndex];
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > changeTime)
        {
            elapsedTime = 0;
            currentImageIndex = (currentImageIndex + 1) % images.Count;
            mr.material = images[currentImageIndex];
        }
    }
}
