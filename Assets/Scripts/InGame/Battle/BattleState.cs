using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleState
{
    /// <summary>
    /// ステートマシンクラス
    /// </summary>
    public class StateMachine<TOwner>
    {
        /// <summary>
        /// ステート基底クラス
        /// 各ステートクラスはこのクラスを継承する
        /// </summary>
        public abstract class StateBase
        {
            public StateMachine<TOwner> StateMachine;
            protected TOwner Owner => StateMachine.Owner;

            public virtual void OnEnter() { Debug.Log($"{this} のステートに入った"); }
            public virtual void OnUpdate() { Debug.Log($"{this} のステートに入っている"); }
            public virtual void OnExit() { Debug.Log($"{this} のステートを抜けた"); }
        }
        private TOwner Owner { get; }
        private StateBase _currentState; // 現在のステート
        private StateBase _prevState;    // 前のステート
        private readonly Dictionary<int, StateBase> _states = new Dictionary<int, StateBase>(); // 全てのステート定義

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="owner">StateMachineを使用するOwner</param>
        public StateMachine(TOwner owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// ステート定義登録
        /// ステートマシン初期化後にこのメソッドを呼ぶ
        /// </summary>
        /// <param name="stateId">ステートID</param>
        /// <typeparam name="T">ステート型</typeparam>
        public void Add<T>(int stateId) where T : StateBase, new()
        {
            if (_states.ContainsKey(stateId))
            {
                Debug.LogError("ステートがすでに定義されています : " + stateId);
                return;
            }
            // ステート定義を登録
            var newState = new T
            {
                StateMachine = this
            };
            _states.Add(stateId, newState);
        }

        /// <summary>
        /// ステート開始処理
        /// </summary>
        /// <param name="stateId">ステートID</param>
        public void OnStart(int stateId)
        {
            if (!_states.TryGetValue(stateId, out var nextState))
            {
                Debug.LogError("ステートのIDが設定されていません : " + stateId);
                return;
            }
            // 現在のステートに設定して処理を開始
            _currentState = nextState;
            _currentState.OnEnter();
        }

        /// <summary>
        /// ステート更新処理
        /// </summary>
        public void OnUpdate()
        {
            _currentState.OnUpdate();
        }

        /// <summary>
        /// 次のステートに切り替える
        /// </summary>
        /// <param name="stateId">切り替えるステートID</param>
        public void ChangeState(int stateId)
        {
            if (!_states.TryGetValue(stateId, out var nextState))
            {
                Debug.LogError("ステートのIDが設定されていません : " + stateId);
                return;
            }
            // 前のステートを保持
            _prevState = _currentState;
            // ステートを切り替える
            _currentState.OnExit();
            _currentState = nextState;
            _currentState.OnEnter();
        }

        /// <summary>
        /// 前回のステートに切り替える
        /// </summary>
        public void ChangePrevState()
        {
            if (_prevState == null)
            {
                Debug.LogError("前回のステートが参照できません");
                return;
            }
            // 前のステートと現在のステートを入れ替える
            (_prevState, _currentState) = (_currentState, _prevState);
        }
    }
}
