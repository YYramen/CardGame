using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�[�����Ǘ�����X�e�[�g�}�V���R���|�[�l���g
/// </summary>
public class BattleStateMachine : BattleStateMachineBase<BattleStateMachine>
{
    // TODO: �{�^�����������Ƃ��ɃX�e�[�g���J�ڂ���悤�ɂ���(�J�ڂ̏��Ԃ͌Œ�)
    private void Start()
    {
        ChangeState(new EnterBattle(this));
    }

    public class EnterBattle : BattleStateBase<BattleStateMachine>
    {
        public EnterBattle(BattleStateMachine machine) : base(machine)
        {
        }
        public override void OnEnterState()
        {
            Debug.Log("EnterBattle State �ɓ�����");
        }
        public override void OnUpdate()
        {
            
        }
        public override void OnExitState()
        {
            Debug.Log("EnterBattle State ���o��");
        }
    }

    public class PlayerTurn : BattleStateBase<BattleStateMachine>
    {
        public PlayerTurn(BattleStateMachine machine) : base(machine)
        {
        }
        public override void OnEnterState()
        {
            Debug.Log("PlayerTurn State �ɓ�����");
        }
        public override void OnUpdate()
        {

        }
        public override void OnExitState()
        {
            Debug.Log("PlayerTurn State ���o��");
        }
    }

    public class EnemyTurn : BattleStateBase<BattleStateMachine>
    {
        public EnemyTurn(BattleStateMachine machine) : base(machine)
        {
        }
        public override void OnEnterState()
        {
            Debug.Log("EnemyTurn State �ɓ�����");
        }
        public override void OnUpdate()
        {

        }
        public override void OnExitState()
        {
            Debug.Log("EnemyTurn State ���o��");
        }
    }

    public class ExitBattle : BattleStateBase<BattleStateMachine>
    {
        public ExitBattle(BattleStateMachine machine) : base(machine)
        {
        }
        public override void OnEnterState()
        {
            Debug.Log("ExitBattle State �ɓ�����");
        }
        public override void OnUpdate()
        {

        }
        public override void OnExitState()
        {
            Debug.Log("ExitBattle State ���o��");
        }
    }
}
