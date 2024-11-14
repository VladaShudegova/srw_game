using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private CharacterInputController _inputController;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _inputController = GetComponent<CharacterInputController>();

        _states = new Dictionary<Type, State>()
        {
            [typeof(GroundedState)] = new GroundedState(this, _playerMovement, _inputController),
            [typeof(JumpingState)]  = new JumpingState(this, _playerMovement, _inputController) 
        };
    }

    public void SetPlayer(PlayerMovement player)
    {
        _playerMovement = player;
    }
}
