using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードのパラメータ及びImageを設定するためのScriptableObject
/// </summary>
[CreateAssetMenu]
public class CardParamsAsset : ScriptableObject
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
}
