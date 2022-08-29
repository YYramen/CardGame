using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒQ[ƒ€‚Ìî•ñ‚ğŠÇ—‚·‚éƒNƒ‰ƒX
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
