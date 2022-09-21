using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードの”モデル”となる。Resources/Cardsフォルダ内の情報を取得するコンポーネント
/// </summary>

public class CardData
{
    [SerializeField] int _id;
    public int Id => _id;
    [SerializeField] string _name;
    public string Name => _name;
    [SerializeField] int _cost;
    public int Cost => _cost;
    [SerializeField] int _effectPoint;
    public int EffectPoint => _effectPoint;
    [SerializeField] string _description;
    public string Description => _description;
    [SerializeField] Image _cardImage;
    public Image CardImage => _cardImage;

    /// <summary>
    /// 情報を取得して変数に代入する
    /// </summary>
    /// <param name="id">カードのID</param>
    public void CardModel(int id)
    {
        CardParamsAsset param = Resources.Load<CardParamsAsset>($"Cards/{id}");

        _name = param.Name;
        _cost = param.Cost;
        _effectPoint = param.EffectPoint;
        _description = param.Description;
        _cardImage = param.CardImage;
    }
}

