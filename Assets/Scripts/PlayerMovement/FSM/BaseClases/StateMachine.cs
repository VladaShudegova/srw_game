using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected Dictionary<Type, State> _states;

    public State CurrentState { get; private set; }
    public State PreviousState { get; private set; }

    public virtual void EnterIn<TState>() where TState : State
    {
        if (_states.TryGetValue(typeof(TState), out State state))
        {
            PreviousState = CurrentState;
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
