using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectName;

    //Parent class for the interactable objects.
    public virtual void Interact()
    {
        Debug.Log("No implementation for the interaction of this object");
    }

    public string GetName()
    {
        return objectName;
    }
}
