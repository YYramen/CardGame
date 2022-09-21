using System.Linq;
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
    [SerializeField] List<CardController> _deckCards = new List<CardController>();
    [SerializeField] List<CardController> _recycleCards = new List<CardController>();

    [SerializeField] Player _player;

    [SerializeField] List<Warrior> _enemies = new List<Warrior>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    /// <summary>
    /// プレイヤーのターン開始時に呼ぶコストをリセットする処理
    /// </summary>
    public void RefillCost()
    {
        _player.ResetCost();
    }

    /// <summary>
    /// プレイヤーのターン開始時に呼ぶカードを引く処理
    /// </summary>
    public void TakeCard()
    {
        for (int i = 0; i < 5; i++)
        {
            CardController cc = Instantiate(_deckCards[i], _deckPos);
            cc.Init();
            Debug.Log($"デッキからカードを取得");
        }
    }

    /// <summary>
    /// プレイヤーのターン終了時に呼ばれる,カードを捨てデッキに移動させる処理
    /// </summary>
    public void RemoveCards()
    {
        for (int i = 0; i < _deckCards.Count; i++)
        {
            _recycleCards.Add(_deckCards[i]);
        }

        foreach (Transform card in _deckPos.transform)
        {
            Destroy(card.gameObject);
        }
        Debug.Log("カードを捨て札に移動しました");
    }
}
