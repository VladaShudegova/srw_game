

public class GroundedState : PlayerBaseState
{
    private bool IsJuming;

    public GroundedState(StateMachine stateMachine, PlayerMovement playerMovement, CharacterInputController inputController) : base(stateMachine, playerMovement, inputController)
    {
    }

    public override void Enter()
    {
        base.Enter();
        IsJuming = false;
        inputController.jumpPerformed += () => IsJuming = true;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(IsJuming && grounded)
        {
            IsJuming = false;
            stateMachine.EnterIn<JumpingState>();
        }
    }
}
