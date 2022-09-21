using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの挙動を制御するコンポーネント
/// </summary>
[Serializable]
public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("HP")] int _hp = 20;
    public int HP => _hp;

    [SerializeField, Tooltip("コスト")] byte cost = 3;

    [SerializeField, Tooltip("所持金")] int _money;
    public int Money => _money;
    
}
