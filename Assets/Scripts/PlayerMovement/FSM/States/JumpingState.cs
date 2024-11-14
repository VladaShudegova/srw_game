using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpingState : PlayerBaseState
{
    public JumpingState(StateMachine stateMachine, PlayerMovement playerMovement, CharacterInputController inputController) : base(stateMachine, playerMovement, inputController)
    {
    }

    public override void Enter()
    {
        base.Enter();
        inputController.jumpCanceled += JumpCanceled;
        _currentSpeed.y = Mathf.Sqrt(2 * playerMovement.JumpHeight * Mathf.Abs(Physics2D.gravity.y));
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        inputController.jumpCanceled -= JumpCanceled;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(grounded)
        {
            _currentSpeed.y = 0f;
            stateMachine.EnterIn<GroundedState>();
        }
    }

    private void JumpCanceled()
    {
        if(_currentSpeed.y > 0)
        {
            _currentSpeed.y = 0;
        }
    }
}
