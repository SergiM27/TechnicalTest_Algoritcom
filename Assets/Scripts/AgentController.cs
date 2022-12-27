using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    IInput input;
    AgentMovement movement;

    private void OnEnable() //When game boots, assign variables and call events.
    {
        input = GetComponent<IInput>();
        movement = GetComponent<AgentMovement>();
        input.onMovementDirectionInput += movement.HandleMovementDirection;
        input.onMovementInput += movement.HandleMovement;
    }

    private void OnDisable() //When game ends, disassign variables and call events.
    {
        input.onMovementDirectionInput -= movement.HandleMovementDirection;
        input.onMovementInput -= movement.HandleMovement;
    }
}
