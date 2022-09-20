using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの情報を管理するクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Transform _deckPos;
    [SerializeField] CardController[] _cardPrefabs;
    [SerializeField] int _currentCoins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// プレイヤーのターン開始時に呼ぶカードを引く処理
    /// </summary>
    public void TakeCard()
    {
        foreach(var card in _cardPrefabs)
        {
            CardController cc = Instantiate(card, _deckPos);
            cc.Init(card.Id);
        }
    }

    /// <summary>
    /// プレイヤーのターン終了時に呼ばれるカードを削除する処理
    /// </summary>
    public void RemoveCards()
    {

    }
}
