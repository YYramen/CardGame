using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードの動きを制御するコンポーネント
/// </summary>
public class CardController : MonoBehaviour
{
    CardData _cardData;
    [SerializeField] int _id;
    public int Id => _id;

    public void Init(int id)
    {
        _cardData = new CardData(_id);
    }

    public void OnClick()
    {
        Debug.Log(this._cardData);
    }
}
