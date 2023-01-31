using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    public delegate void PlayerMoveEvent(bool val);
    public event PlayerMoveEvent OnPlayerMoving;

    private bool playerIsMoving = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void PlayerIsMoving(bool val)
    {
        playerIsMoving = val;

        if(OnPlayerMoving != null) OnPlayerMoving(val);
    }

    public bool PlayerIsMoving()
    {
        return playerIsMoving;
    }
}
