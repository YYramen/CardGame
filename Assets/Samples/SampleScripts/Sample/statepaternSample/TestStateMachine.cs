using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateMachine : StateMachineBase<TestStateMachine>
{
	private void Start()
	{
		ChangeState(new TestStateMachine.Neutral(this));
	}
    private void Update()
    {
		
    }

	private class Neutral : StateBase<TestStateMachine>
	{
		public Neutral(TestStateMachine _machine) : base(_machine)
		{
		}
		public override void OnEnterState()
		{
			
		}
		public override void OnUpdate()
		{
			
		}
	}

	private class Up : StateBase<TestStateMachine>
	{
		public Up(TestStateMachine _machine) : base(_machine)
		{
		}
		public override void OnEnterState()
		{
			
		}
		public override void OnUpdate()
		{
			
		}
	}

	private class Left : StateBase<TestStateMachine>
	{
		public Left(TestStateMachine _machine) : base(_machine)
		{
		}
		public override void OnEnterState()
		{
			
		}
		public override void OnUpdate()
		{
			
		}
	}
}
