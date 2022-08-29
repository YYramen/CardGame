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
        // Animatorコンポーネントの参照を取得
        Animator _anim = this.GetComponent<Animator>();

        // AnimatorからObservableStateMachineTriggerの参照を取得
        ObservableStateMachineTrigger _trigger =
            _anim.GetBehaviour<ObservableStateMachineTrigger>();

        //// Stateの開始イベント
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

        //// Stateの終了イベント
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
        // Stateの開始イベント
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

        // Stateの終了イベント
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
