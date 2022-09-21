using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text _nameText, _pointText, _costText, _desText;
    [SerializeField] Image _cardImg;

    /// <summary>
    /// CardData�R���|�[�l���g��������擾���ĕ\������
    /// </summary>
    /// <param name="cardData"></param>
    public void View(CardData cardData)
    {
        _nameText.text = cardData.Name;
        _desText.text = cardData.Description;
        _pointText.text = cardData.EffectPoint.ToString();
        _costText.text = cardData.Cost.ToString();
        _cardImg = cardData.CardImage;
    }
}
