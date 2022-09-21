using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleState;
using TMPro.EditorUtilities;

/// <summary>
/// ステートのタイプ
/// </summary>
public enum StateType : int
{
    PlayerTurn = 0,
    EnemyTurn = 1,
    Result = 2,
}

/// <summary>
/// ステートマシンの実行部分
/// </summary>
public class BattleStateMachine : MonoBehaviour
{
    StateMachine<BattleStateMachine> _stateMachine;

    

    private void Start()
    {
        _stateMachine = new StateMachine<BattleStateMachine>(this);

        _stateMachine.Add<PlayerTurn>((int)StateType.PlayerTurn);
        _stateMachine.Add<EnemyTurn>((int)StateType.EnemyTurn);
        _stateMachine.Add<Result>((int)StateType.Result);

        _stateMachine.OnStart((int)StateType.PlayerTurn);
    }

    private void Update()
    {
        _stateMachine.OnUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            ChangeState(1);
        }
    }

    public void ChangeState(int nextState)
    {
        _stateMachine.ChangeState(nextState);
    }

    private class PlayerTurn : StateMachine<BattleStateMachine>.StateBase
    {
        public override void OnEnter()
        {
            base.OnEnter();

            GameManager.Instance.TakeCard();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }

    private class EnemyTurn : StateMachine<BattleStateMachine>.StateBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }

    private class Result : StateMachine<BattleStateMachine>.StateBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
