using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーと敵のターン、バトル終了時の挙動を管理する
/// </summary>
public class BattleStateBase<T> where T : BattleStateMachineBase<T>
{
	protected T _machine;
	public BattleStateBase(T machine) { _machine = machine; }
	public virtual void OnEnterState() { }
	public virtual void OnUpdate() { }
	public virtual void OnExitState() { }
}
