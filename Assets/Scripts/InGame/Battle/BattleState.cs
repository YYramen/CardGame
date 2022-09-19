using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleState
{
    /// <summary>
    /// �X�e�[�g�}�V���N���X
    /// ��ԑJ�ڂ̒�`��
    /// </summary>
    public class StateMachine<T>
    {
        /// <summary>
        /// �X�e�[�g���N���X
        /// �e�X�e�[�g�N���X�͂��̃N���X���p������
        /// </summary>
        public abstract class StateBase
        {
            public StateMachine<T> StateMachine;
            protected T Owner => StateMachine.Owner;
            // �X�e�[�g�J�ڏ��
            public readonly Dictionary<int, StateBase> Transitions = new Dictionary<int, StateBase>(); 

            public virtual void OnStart() { }
            public virtual void OnUpdate() { }
            public virtual void OnEnd() { }
        }
        private T Owner { get; }
        // ���݂̃X�e�[�g
        private StateBase _currentState;
        // �S�ẴX�e�[�g��`
        private readonly LinkedList<StateBase> _states = new LinkedList<StateBase>(); 

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="owner">StateMachine���g�p����Owner</param>
        public StateMachine(T owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// �X�e�[�g�ǉ�
        /// </summary>
        private T Add<T>() where T : StateBase, new()
        {
            // �X�e�[�g��ǉ�
            var newState = new T
            {
                StateMachine = this
            };
            _states.AddLast(newState);
            return newState;
        }

        /// <summary>
        /// �X�e�[�g�擾�A������Βǉ�
        /// </summary>
        private T GetOrAdd<T>() where T : StateBase, new()
        {
            // �ǉ�����Ă���Εԋp
            foreach (var state in _states)
            {
                if (state is T result)
                {
                    return result;
                }
            }
            // ������Βǉ�
            return Add<T>();
        }

        /// <summary>
        /// �C�x���gID�ɑΉ������J�ڏ���o�^
        /// </summary>
        /// <param name="eventId">�C�x���gID</param>
        /// <typeparam name="TFrom">�J�ڌ��X�e�[�g</typeparam>
        /// <typeparam name="TTo">�J�ڐ�X�e�[�g</typeparam>
        public void AddTransition<TFrom, TTo>(int eventId)
            where TFrom : StateBase, new()
            where TTo : StateBase, new()
        {
            // ���ɃC�x���gID���o�^�ςȂ�G���[
            var from = GetOrAdd<TFrom>();
            if (from.Transitions.ContainsKey(eventId))
            {
                Debug.LogError("already register eventId!! : " + eventId);
                return;
            }
            // �w��̃C�x���gID�Œǉ�����
            var to = GetOrAdd<TTo>();
            from.Transitions.Add(eventId, to);
        }

        /// <summary>
        /// �X�e�[�g�J�n����
        /// </summary>
        /// <typeparam name="T">�J�n����X�e�[�g</typeparam>
        public void OnStart<T>() where T : StateBase, new()
        {
            _currentState = GetOrAdd<T>();
            _currentState.OnStart();
        }

        /// <summary>
        /// �X�e�[�g�X�V����
        /// </summary>
        public void OnUpdate()
        {
            _currentState.OnUpdate();
        }

        /// <summary>
        /// �C�x���g���s
        /// �w�肳�ꂽID�̃X�e�[�g�ɐ؂�ւ���
        /// </summary>
        /// <param name="eventId">�C�x���gID</param>
        public void DispatchEvent(int eventId)
        {
            // �C�x���gID����X�e�[�g�擾
            if (!_currentState.Transitions.TryGetValue(eventId, out var nextState))
            {
                Debug.LogError("not found eventId!! : " + eventId);
                return;
            }
            // �X�e�[�g��؂�ւ���
            _currentState.OnEnd();
            nextState.OnStart();
            _currentState = nextState;
        }
    }
}
