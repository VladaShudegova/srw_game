using UnityEngine;

public class GroundedState : PlayerBaseState
{
    public GroundedState(StateMachine stateMachine, PlayerMovement playerMovement) : base(stateMachine, playerMovement)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Grounded State");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!s_grounded)
        {
            stateMachine.EnterIn<FallingState>();
        }

        if(playerMovement.Jump)
        {
            stateMachine.EnterIn<JumpingState>();
        }
    }
}
