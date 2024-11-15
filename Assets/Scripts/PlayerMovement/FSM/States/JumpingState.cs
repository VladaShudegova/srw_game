using UnityEngine;

public class JumpingState : AirState
{
    private float jumpSpeed;
    public JumpingState(StateMachine stateMachine, PlayerMovement playerMovement) : base(stateMachine, playerMovement)
    {
    }

    public override void Enter()
    {
        base.Enter();
        jumpSpeed = Mathf.Sqrt(2 * playerMovement.JumpHeight * Mathf.Abs(Physics2D.gravity.y));
        s_currentSpeed.y = jumpSpeed;
        Debug.Log("Jumping State");
    }

    public override void Update()
    {
        base.Update();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!playerMovement.Jump)
            JumpCanceled();

        if(s_currentSpeed.y <= -jumpSpeed)
        {
            stateMachine.EnterIn<FallingState>();
        }
    }
    
    private void JumpCanceled()
    {
        if(s_currentSpeed.y > 0)
        {
            s_currentSpeed.y = 0;
        }
    }

}
