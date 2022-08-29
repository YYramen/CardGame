using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードのベースクラス
/// </summary>
public abstract class CardBase : MonoBehaviour
{
    [SerializeField] Text _nameText;
    [SerializeField] Text _costText;
    [SerializeField] Text _effectText;
    [SerializeField] Image _image;

    public void Execute()
    {
        OnExcute();
    }

    public abstract void OnExcute();

    public void ChangeCost(int cost)
    {
        _costText.text += cost.ToString();
    }

    public void EffectChange()
    {

    }
}
