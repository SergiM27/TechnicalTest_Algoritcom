using System;
using UnityEngine;

public interface IInput
{
    Action<Vector3> onMovementDirectionInput { get; set; }
    Action<Vector2> onMovementInput { get; set; }
}