
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    public GameInput GameInput {  get; private set; }

    public event Action jumpPerformed;
    public event Action jumpCanceled;

    private Vector2 _inputDirection;

    private void Update()
    {
        ReadMovement();
    }

    private void Awake() {
        GameInput = new GameInput();
        GameInput.Enable();
    }

    private void OnEnable()
    {
        GameInput.Gameplay.Jump.performed += OnJumpPerformed;
        GameInput.Gameplay.Jump.canceled += OnJumpCanceled;
    }



    private void OnDisable()
    {
        GameInput.Gameplay.Jump.performed -= OnJumpPerformed;
        GameInput.Gameplay.Jump.canceled -= OnJumpCanceled;
    }


    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        jumpPerformed?.Invoke();
    }

    private void OnJumpCanceled(InputAction.CallbackContext obj)
    {
        jumpCanceled?.Invoke();
    }

    private void ReadMovement()
    {
        Vector2 inputDirection = GameInput.Gameplay.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetInput()
    {
        return _inputDirection;
    }

}
