using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    private bool isOpen;

    //Interaction for the doors that don't move by themselves.
    public override void Interact()
    {
        isOpen = !isOpen;
        transform.parent.GetComponent<Animator>().SetBool("Open", isOpen);
    }
}
