using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraInteraction : MonoBehaviour
{
    private  new Transform camera;
    public int rayDistance;
    public TextMeshProUGUI canvasText;
    private bool textShowing;
    private void Start()
    {
        camera = GameObject.Find("Main Camera").transform;
        canvasText.gameObject.SetActive(false);
        textShowing = false;
    }

    
    private void Update()
    {
        //Camera's Raycast to be able to interact with the environment.
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
            if(hit.transform.tag == "Interactable")
            {
                if (textShowing == false)
                {
                    canvasText.text = hit.transform.GetComponent<Interactable>().GetName();
                    canvasText.gameObject.SetActive(true);
                    textShowing = true;
                }
            }
        }
        else
        {
            if (textShowing)
            {
                canvasText.gameObject.SetActive(false);
                textShowing = false;
            }
        }
        if (Input.GetButtonDown("Interactable")) //E
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactable")))
            {
                if(hit.transform.GetComponent<Interactable>()!=null)
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}

