using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
    public static Positions Instance { get; private set; }
    [SerializeField] List<Transform> positions;

    void Awake()
    {
        Instance = this;
    }

    public List<Transform> GetPositions()
    {
        return positions;
    }
}
