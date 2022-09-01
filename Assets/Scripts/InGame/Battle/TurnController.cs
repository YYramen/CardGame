using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TurnState;

/// <summary>
/// 実際にターンを動かすコンポーネント
/// </summary>
public class TurnController : MonoBehaviour
{
    //変更前のステート名
    private string _prevStateName;

    //ステート
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public TurnStatePlayer StatePlayerTurn { get; set; } = new TurnStatePlayer();
    public TurnStateEnemy StateEnemyTurn { get; set; } = new TurnStateEnemy();
    public TurnStateResult StateResultTurn { get; set; } = new TurnStateResult();

    private void Start()
    {
        //ステートの初期化
        StateProcessor.State.Value = StatePlayerTurn;
        StatePlayerTurn.ExecAction = TurnChange;
        StateEnemyTurn.ExecAction = EnemyTurn;
        StateResultTurn.ExecAction = ResultTurn;

        //ステートの値が変更されたら実行処理を行うようにする
        StateProcessor.State
            .Where(_ => StateProcessor.State.Value.GetStateName() != _prevStateName)
            .Subscribe(_ =>
            {
                Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
                _prevStateName = StateProcessor.State.Value.GetStateName();
                StateProcessor.Execute();
            })
            .AddTo(this);
    }

    public void TurnChange()
    {
        StateProcessor.State.Value.ExecAction = TurnChange;
    }

    public void EnemyTurn()
    {
        Debug.Log("StateがEnemyTurnに状態遷移しました。");
    }

    public void ResultTurn()
    {
        Debug.Log("StateがResultに状態遷移しました。");
    }

}
