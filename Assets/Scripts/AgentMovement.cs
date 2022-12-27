using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{

    Rigidbody rb;
    Vector3 movementVector = Vector3.zero;

    public float rotationSpeed, movementSpeed;
    private float desiredRotationAngle = 0, rotationThreshold = 10;

    public bool isSit;
    public GameObject chair;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isSit = false;
    }

    //Movement of the player. Takes input values from the PlayerInput class and applies them to the rigidbody.
    public void HandleMovement(Vector2 input)
    {
        if (isSit == false)
        {
            if (input.magnitude == 0)
            {
                movementVector = Vector3.zero;
            }
            else
            {
                movementVector = transform.TransformDirection(new Vector3(input.x, 0, input.y));
            }
            rb.velocity = movementVector * movementSpeed * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (isSit == false) //If he is sat he shouldn't be able to rotate.
        {
            RotateAgent();
        }
        else
        {
            StandUp();
        }

    }

    public void HandleMovementDirection(Vector3 direction)
    {
        if (isSit == false)
        {
            //This gets us the angle that the character need to rotate, but it will always be positive.
            desiredRotationAngle = Vector3.Angle(transform.forward, direction);
            //Cross product is calculated so we then can see if the value should be positive or negative.
            var crossProduct = Vector3.Cross(transform.forward, direction).y;
            if (crossProduct < 0)
            {
                desiredRotationAngle *= -1;
            }
        }
    }

    private void RotateAgent()
    {
        //Player rotation following the camera's rotation.
        if (desiredRotationAngle > rotationThreshold || desiredRotationAngle < -rotationThreshold)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    public void StandUp()
    {
        if (Input.GetKeyDown(KeyCode.W)) //If player presses W, he stands up if he is sat.
        {
            if (isSit)
            {
                GetComponent<Animator>().SetBool("IsSit", false);
            }
        }
    }

    public void StandUpAnimation() //Event for the animation of standing up. Once it is over, the player is able to move again.
    {
        isSit = false;
        chair.GetComponent<BoxCollider>().enabled = true;
        GetComponent<CapsuleCollider>().height = 1.9f;
        chair = null;
    }
}
