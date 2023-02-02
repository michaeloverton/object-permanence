using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    public delegate void PlayerMoveEvent(bool val);
    public event PlayerMoveEvent OnPlayerMoving;
    private bool playerIsMoving = false;

    public delegate void PlayerFreezeEvent(bool val);
    public event PlayerFreezeEvent OnFreezePlayer;

    // Start is called before the first frame update
    void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
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

    public void FreezePlayer(bool val)
    {
        if(OnFreezePlayer != null) OnFreezePlayer(val);
    }
}
