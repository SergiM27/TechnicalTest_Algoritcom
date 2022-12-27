using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSliderDoors : MonoBehaviour
{

    public Animator door;

    //Interactions for the slider doors.
    private void OnTriggerEnter(Collider other)
    {
        door.SetBool("Open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        door.SetBool("Open", false);
    }
}
