using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Remember()
    {
        SceneManager.LoadScene("Main");
    }

    public void Forget()
    {
        SceneManager.LoadScene("Title");
    }
}
