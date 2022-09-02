using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

    /// <summary>
/// �^�[���̏�ԁi�X�e�[�g�j
/// </summary>
namespace TurnState
{
    /// <summary>
    /// �X�e�[�g�̎��s���Ǘ�����N���X
    /// </summary>
    public class StateProcessor
    {
        //�X�e�[�g�{��
        public ReactiveProperty<TurnState> State { get; set; } = new ReactiveProperty<TurnState>();

        //���s�u���b�W
        public void Execute() => State.Value.Execute();
    }

    /// <summary>
    /// �X�e�[�g�̃N���X
    /// </summary>
    public abstract class TurnState
    {
        //�f���Q�[�g
        public Action ExecAction { get; set; }

        //���s����
        public virtual void Execute()
        {
            if (ExecAction != null) ExecAction();
        }

        //�X�e�[�g�����擾���郁�\�b�h
        public abstract string GetStateName();
    }

    //-------------------------------�ȉ��̓^�[���̃N���X-------------------------------//

    /// <summary>
    /// �v���C���[�̃^�[��
    /// </summary>
    public class TurnStatePlayer : TurnState
    {
        public override string GetStateName()
        {
            return "State:Player";
        }
    }

    /// <summary>
    /// �G�l�~�[�̃^�[��
    /// </summary>
    public class TurnStateEnemy : TurnState
    {
        public override string GetStateName()
        {
            return "State:Enemy";
        }
    }

    /// <summary>
    /// ���U���g
    /// </summary>
    public class TurnStateResult : TurnState
    {
        public override string GetStateName()
        {
            return "State:Result";
        }

        public override void Execute()
        {
            Debug.Log("�Ȃɂ����ʂȏ������������Ƃ��͔h���N���X�ɂď��������Ă��ǂ�");
            if (ExecAction != null) ExecAction();
        }
    }
}
