using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexChaos : MonoBehaviour
{
    Material mat;
    [SerializeField] float maxDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        Manager.Instance.OnPlayerMoving += SetVertexChaos;
    }

    void Update() 
    {
        mat.SetFloat("_MaxDistance", Mathf.Pow(Timer.Instance.GetTimeUsedRatio(), 2) * maxDistance);
    }

    void SetVertexChaos(bool val) {
        // if(val)
        // {
        //     mat.SetFloat("_MaxDistance", Timer.Instance.GetTimeUsedRatio() * maxDistance);
        // }
        // else
        // {
        //     mat.SetFloat("_MaxDistance", 0f);
        // }
    }
}
