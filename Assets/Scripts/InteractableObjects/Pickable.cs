using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{

    //Interaction for any pickable object (shoes in this project).
    public override void Interact()
    {
        Destroy(gameObject);
    }
}
