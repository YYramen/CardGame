using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleState;

public class BattleStateMachine : MonoBehaviour
{
    private enum StateType
    {
        PlayerTurn,
        EnemyTurn,
        Result,
    }

    StateMachine<BattleStateMachine> _stateMachine;

    private void Start()
    {
        //_stateMachine = new StateMachine<BattleStateMachine>(this);

        //_stateMachine.AddTransition<PlayerTurn,EnemyTurn>((int)StateType.PlayerTurn);
        //_stateMachine.AddTransition<EnemyTurn,PlayerTurn>((int)StateType.EnemyTurn);
        //_stateMachine.AddTransition<EnemyTurn, Result>((int)StateType.Result);
        //// ステート開始
        //_stateMachine.OnStart<PlayerTurn>();
    }
}
