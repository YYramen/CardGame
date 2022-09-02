using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class SampleUniRx : MonoBehaviour
{
    Animator _anim;
    ObservableStateMachineTrigger _trigger;

    private void Start()
    {
        // Animator�R���|�[�l���g�̎Q�Ƃ��擾
        Animator _anim = this.GetComponent<Animator>();

        // Animator����ObservableStateMachineTrigger�̎Q�Ƃ��擾
        ObservableStateMachineTrigger _trigger =
            _anim.GetBehaviour<ObservableStateMachineTrigger>();

        //// State�̊J�n�C�x���g
        //IDisposable enterState = trigger
        //    .OnStateEnterAsObservable()
        //    .Subscribe(onStateInfo =>
        //    {
        //        AnimatorStateInfo info = onStateInfo.StateInfo;
        //        if (info.IsName("Base Layer.LoopAction"))
        //        {
        //            Debug.Log("Enter to LoopAction");
        //        }
        //    }).AddTo(this);

        //// State�̏I���C�x���g
        //IDisposable exitState = trigger
        //    .OnStateExitAsObservable()
        //    .Subscribe(onStateInfo =>
        //    {
        //        AnimatorStateInfo info = onStateInfo.StateInfo;
        //        if (info.IsName("Base Layer.LoopAction"))
        //        {
        //            Debug.Log("Exit from LoopAction");
        //        }
        //    }).AddTo(this);
    }

    

    private void Update()
    {
        // State�̊J�n�C�x���g
        IDisposable enterState = _trigger
            .OnStateEnterAsObservable()
            .Subscribe(onStateInfo =>
            {
                AnimatorStateInfo info = onStateInfo.StateInfo;
                if (info.IsName("Base Layer.LoopAction"))
                {
                    Debug.Log("Enter to LoopAction");
                }
            }).AddTo(this);

        // State�̏I���C�x���g
        IDisposable exitState = _trigger
            .OnStateExitAsObservable()
            .Subscribe(onStateInfo =>
            {
                AnimatorStateInfo info = onStateInfo.StateInfo;
                if (info.IsName("Base Layer.LoopAction"))
                {
                    Debug.Log("Exit from LoopAction");
                }
            }).AddTo(this);
    }
}
