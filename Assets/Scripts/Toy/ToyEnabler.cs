using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyEnabler : MonoBehaviour
{
    [SerializeField] private List<GameObject> toysToEnable;

    public void Enable(string name)
    {
        this.gameObject.SetActive(false);

        // this is a janky hack but it will work.
        string tag = "";
        switch(name)
        {
            case "SWORD":
                tag = "Sword";
                break;
            case "FIRE HAT":
                tag = "FireHat";
                break;
            case "SHIELD":
                tag = "Shield";
                break;
            default:
                Debug.LogError("TOY NOT FOUND");
                break;
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(tag))
        {
            obj.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
