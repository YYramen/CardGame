using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

    /// <summary>
/// ターンの状態（ステート）
/// </summary>
namespace TurnState
{
    /// <summary>
    /// ステートの実行を管理するクラス
    /// </summary>
    public class StateProcessor
    {
        //ステート本体
        public ReactiveProperty<TurnrState> State { get; set; } = new ReactiveProperty<TurnrState>();

        //実行ブリッジ
        public void Execute() => State.Value.Execute();
    }

    /// <summary>
    /// ステートのクラス
    /// </summary>
    public abstract class TurnrState
    {
        //デリゲート
        public Action ExecAction { get; set; }

        //実行処理
        public virtual void Execute()
        {
            if (ExecAction != null) ExecAction();
        }

        //ステート名を取得するメソッド
        public abstract string GetStateName();
    }

    //-------------------------------以下はターンのクラス-------------------------------//

    /// <summary>
    /// プレイヤーのターン
    /// </summary>
    public class TurnStatePlayer : TurnrState
    {
        public override string GetStateName()
        {
            return "State:Player";
        }
    }

    /// <summary>
    /// エネミーのターン
    /// </summary>
    public class TurnStateEnemy : TurnrState
    {
        public override string GetStateName()
        {
            return "State:Enemy";
        }
    }

    /// <summary>
    /// リザルト
    /// </summary>
    public class TurnStateResult : TurnrState
    {
        public override string GetStateName()
        {
            return "State:Result";
        }

        public override void Execute()
        {
            Debug.Log("なにか特別な処理をしたいときは派生クラスにて処理をしても良い");
            if (ExecAction != null) ExecAction();
        }
    }
}
