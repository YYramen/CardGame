using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���̏����Ǘ�����N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] CardController[] _cardPrefabs;
    [SerializeField] Transform _deckPos;

    private void Start()
    {
        CreateCard(_deckPos);
    }

    private void CreateCard(Transform deck)
    {
        foreach (var card in _cardPrefabs)
        {
            CardController cc = Instantiate(card, _deckPos);
            cc.Init(card.Id);
        }
    }
}
