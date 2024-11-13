using UnityEngine;

public interface IControllable 
{
    void InputUpdate(Vector2 inputDirection);
    void Jump();
}