using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの情報を管理するクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] CardController _cardPrefab;
    [SerializeField] Transform _deckPos;
    [SerializeField] int _id;

    private void Start()
    {
        CreateCard(_deckPos);
    }

    void CreateCard(Transform deck)
    {
        CardController cc = Instantiate(_cardPrefab, deck);
        cc.Init(_id);
    }
}
