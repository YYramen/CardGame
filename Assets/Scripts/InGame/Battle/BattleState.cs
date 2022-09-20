using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleState
{
    /// <summary>
    /// �X�e�[�g�}�V���N���X
    /// </summary>
    public class StateMachine<TOwner>
    {
        /// <summary>
        /// �X�e�[�g���N���X
        /// �e�X�e�[�g�N���X�͂��̃N���X���p������
        /// </summary>
        public abstract class StateBase
        {
            public StateMachine<TOwner> StateMachine;
            protected TOwner Owner => StateMachine.Owner;

            public virtual void OnEnter() { Debug.Log($"{this} �̃X�e�[�g�ɓ�����"); }
            public virtual void OnUpdate() { Debug.Log($"{this} �̃X�e�[�g�ɓ����Ă���"); }
            public virtual void OnExit() { Debug.Log($"{this} �̃X�e�[�g�𔲂���"); }
        }
        private TOwner Owner { get; }
        private StateBase _currentState; // ���݂̃X�e�[�g
        private StateBase _prevState;    // �O�̃X�e�[�g
        private readonly Dictionary<int, StateBase> _states = new Dictionary<int, StateBase>(); // �S�ẴX�e�[�g��`

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="owner">StateMachine���g�p����Owner</param>
        public StateMachine(TOwner owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// �X�e�[�g��`�o�^
        /// �X�e�[�g�}�V����������ɂ��̃��\�b�h���Ă�
        /// </summary>
        /// <param name="stateId">�X�e�[�gID</param>
        /// <typeparam name="T">�X�e�[�g�^</typeparam>
        public void Add<T>(int stateId) where T : StateBase, new()
        {
            if (_states.ContainsKey(stateId))
            {
                Debug.LogError("�X�e�[�g�����łɒ�`����Ă��܂� : " + stateId);
                return;
            }
            // �X�e�[�g��`��o�^
            var newState = new T
            {
                StateMachine = this
            };
            _states.Add(stateId, newState);
        }

        /// <summary>
        /// �X�e�[�g�J�n����
        /// </summary>
        /// <param name="stateId">�X�e�[�gID</param>
        public void OnStart(int stateId)
        {
            if (!_states.TryGetValue(stateId, out var nextState))
            {
                Debug.LogError("�X�e�[�g��ID���ݒ肳��Ă��܂��� : " + stateId);
                return;
            }
            // ���݂̃X�e�[�g�ɐݒ肵�ď������J�n
            _currentState = nextState;
            _currentState.OnEnter();
        }

        /// <summary>
        /// �X�e�[�g�X�V����
        /// </summary>
        public void OnUpdate()
        {
            _currentState.OnUpdate();
        }

        /// <summary>
        /// ���̃X�e�[�g�ɐ؂�ւ���
        /// </summary>
        /// <param name="stateId">�؂�ւ���X�e�[�gID</param>
        public void ChangeState(int stateId)
        {
            if (!_states.TryGetValue(stateId, out var nextState))
            {
                Debug.LogError("�X�e�[�g��ID���ݒ肳��Ă��܂��� : " + stateId);
                return;
            }
            // �O�̃X�e�[�g��ێ�
            _prevState = _currentState;
            // �X�e�[�g��؂�ւ���
            _currentState.OnExit();
            _currentState = nextState;
            _currentState.OnEnter();
        }

        /// <summary>
        /// �O��̃X�e�[�g�ɐ؂�ւ���
        /// </summary>
        public void ChangePrevState()
        {
            if (_prevState == null)
            {
                Debug.LogError("�O��̃X�e�[�g���Q�Ƃł��܂���");
                return;
            }
            // �O�̃X�e�[�g�ƌ��݂̃X�e�[�g�����ւ���
            (_prevState, _currentState) = (_currentState, _prevState);
        }
    }
}
