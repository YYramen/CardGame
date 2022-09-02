using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TurnState;

/// <summary>
/// ���ۂɃ^�[���𓮂����R���|�[�l���g
/// </summary>
public class TurnController : MonoBehaviour
{
    //�ύX�O�̃X�e�[�g��
    string _prevStateName;

    //�X�e�[�g
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public TurnStatePlayer StatePlayerTurn { get; set; } = new TurnStatePlayer();
    public TurnStateEnemy StateEnemyTurn { get; set; } = new TurnStateEnemy();
    public TurnStateResult StateResultTurn { get; set; } = new TurnStateResult();

    private void Start()
    {
        //�X�e�[�g�̏�����
        StateProcessor.State.Value = StatePlayerTurn;
        StatePlayerTurn.ExecAction = PlayerTurn;
        StateEnemyTurn.ExecAction = EnemyTurn;
        StateResultTurn.ExecAction = ResultTurn;

        //�X�e�[�g�̒l���ύX���ꂽ����s�������s���悤�ɂ���
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

    public void PlayerTurn()
    {
        Debug.Log("State��PlayerTurn�ɑJ�ڂ���");
    }

    public void EnemyTurn()
    {
        Debug.Log("State��EnemyTurn�ɑJ�ڂ���");
    }

    public void ResultTurn()
    {
        Debug.Log("State��Result�ɑJ�ڂ���");
    }

}
