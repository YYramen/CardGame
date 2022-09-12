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
            Debug.Log("EnterBattle State ‚É“ü‚Á‚½");
        }
        public override void OnUpdate()
        {
            
        }
        public override void OnExitState()
        {
            
        }
    }
}
