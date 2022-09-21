using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの挙動を制御するコンポーネント
/// </summary>
[Serializable]
public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("HP")] int _hp = 20;
    public int HP => _hp;

    [SerializeField, Tooltip("シールド値")] int _shield = 0;
    public int Shield => _shield;

    [SerializeField, Tooltip("現在のコスト")] byte _currentCost = 0;
    public byte CurrentCost => _currentCost;

    [SerializeField, Tooltip("現在のコスト")] byte _maxCost = 3;
    public byte MaxCost => _maxCost;
    [SerializeField] Text _costText;

    [SerializeField, Tooltip("所持金")] int _money;
    public int Money => _money;

    private void Update()
    {
        _costText.text = $"{_currentCost} / {_maxCost}";
    }

    public void ResetCost()
    {
        _currentCost = _maxCost;
        Debug.Log("コストがリセットされました");
    }

    public void Buff(int value)
    {
        _shield += value;
        Debug.Log("シールドが付与されました");
    }

    public void TakeDamage(int value)
    {
        _hp -= value;
        Debug.Log("プレイヤーがダメージを受けました");
    }
}
