
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    public GameInput GameInput {  get; private set; }
    private IControllable _controllable;

    private void Update()
    {
        ReadMovement();
    }

    private void Awake() {
        GameInput = new GameInput();
        GameInput.Enable();

        _controllable = GetComponent<IControllable>();

        if (_controllable == null)
        {
            throw new Exception("Controller not installed");
        }

    }

    private void OnEnable()
    {
        GameInput.Gameplay.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        GameInput.Gameplay.Jump.performed -= OnJumpPerformed;
    }


    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        _controllable.Jump();
    }

    private void ReadMovement()
    {
        Vector2 inputDirection = GameInput.Gameplay.Movement.ReadValue<Vector2>();
        
        _controllable.InputUpdate(inputDirection);
    }

}
