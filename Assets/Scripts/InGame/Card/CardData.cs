using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �J�[�h�́h���f���h�ƂȂ�BResources/Cards�t�H���_���̏����擾����R���|�[�l���g
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
    /// �����擾���ĕϐ��ɑ������
    /// </summary>
    /// <param name="id">�J�[�h��ID</param>
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

