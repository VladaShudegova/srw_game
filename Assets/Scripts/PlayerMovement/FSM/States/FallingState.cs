using UnityEngine;

public class FallingState : AirState
{
    public FallingState(StateMachine stateMachine, PlayerMovement playerMovement) : base(stateMachine, playerMovement)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Falling State");
    }
}
