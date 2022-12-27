using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerInput : MonoBehaviour, IInput
{

    public Action<Vector2> onMovementInput { get; set; }
    public Action<Vector3> onMovementDirectionInput { get; set; }

    private Animator animator;

    private CinemachineFreeLook cam;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        cam = FindObjectOfType<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMovementInput();
        GetMovementDirection();
        CameraZoom();
    }

    private void CameraZoom() //Camera zoom function
    {
        if (Input.GetMouseButton(1))
        {
            cam.m_Lens.FieldOfView = 10;
        }
        else
        {
            cam.m_Lens.FieldOfView = 40;
        }
    }

    private void GetMovementInput() //Movement inputs for the player.
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        onMovementInput?.Invoke(input);
        animator.SetFloat("MovementX", input.x);
        animator.SetFloat("MovementY", input.y);
    }

    private void GetMovementDirection() //Direction inputs for the player.
    {
        var cameraForwardDirection = Camera.main.transform.forward;
        var directionToMoveTowads = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        onMovementDirectionInput?.Invoke(directionToMoveTowads);
    }
}
