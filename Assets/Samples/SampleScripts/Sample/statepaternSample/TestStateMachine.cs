using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateMachine : StateMachineBase<TestStateMachine>
{
	private void Start()
	{
		ChangeState(new TestStateMachine.Neutral(this));
	}

	private class Neutral : StateBase<TestStateMachine>
	{
		public Neutral(TestStateMachine _machine) : base(_machine)
		{
		}
		public override void OnEnterState()
		{
			Debug.Log("<color=red>OnEnter:Neutral!</color>");
		}
		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				machine.ChangeState(new TestStateMachine.Up(machine));
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				machine.ChangeState(new TestStateMachine.Left(machine));
			}
		}
	}

	private class Up : StateBase<TestStateMachine>
	{
		public Up(TestStateMachine _machine) : base(_machine)
		{
		}
		public override void OnEnterState()
		{
			Debug.Log("<color=blue>OnEnter:Up!</color>");
		}
		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				machine.ChangeState(new TestStateMachine.Neutral(machine));
			}
		}
	}

	private class Left : StateBase<TestStateMachine>
	{
		public Left(TestStateMachine _machine) : base(_machine)
		{
		}
		public override void OnEnterState()
		{
			Debug.Log("<color=purple>OnEnter:Left!</color>");
		}
		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				machine.ChangeState(new TestStateMachine.Neutral(machine));
			}
		}
	}
}
