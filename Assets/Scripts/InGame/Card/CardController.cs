using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�[�h�̓����𐧌䂷��R���|�[�l���g
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
