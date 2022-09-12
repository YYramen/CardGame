using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachineBase<T> : MonoBehaviour where T : BattleStateMachineBase<T>
{
    private BattleStateBase<T> _currentState;
    private BattleStateBase<T> _nextState;

    public bool ChangeState(BattleStateBase<T> nextState)
    {
        bool hasNextState = _nextState == null;
        _nextState = nextState;
        return hasNextState;
    }


    private void Update()
    {
        if (_nextState != null)
        {
            if (_currentState != null)
            {
                _currentState.OnExitState();
            }
            _currentState = _nextState;
            _currentState.OnEnterState();
            _nextState = null;
        }

        if (_currentState != null)
        {
            _currentState.OnUpdate();
        }
    }
}
