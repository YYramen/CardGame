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
    private string _prevStateName;

    //�X�e�[�g
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public TurnStatePlayer StatePlayerTurn { get; set; } = new TurnStatePlayer();
    public TurnStateEnemy StateEnemyTurn { get; set; } = new TurnStateEnemy();
    public TurnStateResult StateResultTurn { get; set; } = new TurnStateResult();

    private void Start()
    {
        //�X�e�[�g�̏�����
        StateProcessor.State.Value = StatePlayerTurn;
        StatePlayerTurn.ExecAction = TurnChange;
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

    public void TurnChange()
    {
        StateProcessor.State.Value.ExecAction = TurnChange;
    }

    public void EnemyTurn()
    {
        Debug.Log("State��EnemyTurn�ɏ�ԑJ�ڂ��܂����B");
    }

    public void ResultTurn()
    {
        Debug.Log("State��Result�ɏ�ԑJ�ڂ��܂����B");
    }

}
