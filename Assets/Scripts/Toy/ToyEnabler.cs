using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyEnabler : MonoBehaviour
{
    [SerializeField] private GameObject toyToEnable;

    public void Enable()
    {
        toyToEnable.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
