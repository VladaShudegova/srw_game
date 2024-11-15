using System;
using System.Collections.Generic;

public class PlayerStateMachine : StateMachine
{
    private CharacterInputController _inputController;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _inputController = GetComponent<CharacterInputController>();

        _states = new Dictionary<Type, State>()
        {
            [typeof(GroundedState)] = new GroundedState(this, _playerMovement),
            [typeof(JumpingState)]  = new JumpingState(this, _playerMovement),
            [typeof(FallingState)] = new FallingState(this, _playerMovement)
        };
    }

    public void SetPlayer(PlayerMovement player)
    {
        _playerMovement = player;
    }
}
