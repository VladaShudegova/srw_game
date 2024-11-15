using UnityEngine;

public class AirState : PlayerBaseState
{
    protected static float s_jumpBufferTimer;
    private bool _jumpBufferTimerStart;
    public AirState(StateMachine stateMachine, PlayerMovement playerMovement) : base(stateMachine, playerMovement)
    {
    }

    public override void Update()
    {
        base.Update();

        if(s_currentSpeed.y > -playerMovement.MaxFallingSpeed)
            s_currentSpeed.y += Physics2D.gravity.y * Time.deltaTime;

        HandleJumpBuffer();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (s_grounded)
        {
            if(s_jumpBufferTimer < playerMovement.JumpBufferTime && _jumpBufferTimerStart)
            {
                stateMachine.EnterIn<JumpingState>();
            }
            s_currentSpeed.y = 0f;
            stateMachine.EnterIn<GroundedState>();

        }
    }

    public override void Exit()
    {
        base.Exit();
        _jumpBufferTimerStart = false;
    }

    private void HandleJumpBuffer()
    {
        if(playerMovement.Jump && s_currentSpeed.y < 0)
        {
            s_jumpBufferTimer = 0f;
            _jumpBufferTimerStart = true;
        }

        if(_jumpBufferTimerStart)
        {
            s_jumpBufferTimer += Time.deltaTime;
        }
    }
}
