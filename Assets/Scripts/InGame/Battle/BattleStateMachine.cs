using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : BattleStateMachineBase<BattleStateMachine>
{
    private void Start()
    {
        ChangeState(new EnterBattle(this));
    }

    private class EnterBattle : BattleStateBase<BattleStateMachine>
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

    private class PlayerTurn : BattleStateBase<BattleStateMachine>
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

    private class EnemyTurn : BattleStateBase<BattleStateMachine>
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

    private class ExitBattle : BattleStateBase<BattleStateMachine>
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
