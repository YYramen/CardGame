using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードのデータクラス
/// </summary>
[Serializable]
public class CardData
{
    string _name;
    string _description;
    int _cost;
    int _effectPoint;
    Image _cardImage;

    public CardData(int id)
    {
        CardParamsAsset asset = Resources.Load<CardParamsAsset>($"Cards/{id}");
        _name = asset.Name;
        _description = asset.Description;
        _cost = asset.Cost;
        _effectPoint = asset.EffectPoint;
        _cardImage = asset.CardImage;
    } 
}

