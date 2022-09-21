using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardData _cardData;
    CardView _cardView;
    [SerializeField] int _id;

    private void Awake()
    {
        _cardView = GetComponent<CardView>();
    }

    public void Init()
    {
        _cardData = new CardData();
        _cardData.CardModel(_id);

        _cardView.View(_cardData);
    }
}
