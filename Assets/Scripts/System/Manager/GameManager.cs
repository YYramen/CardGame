using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���̏����Ǘ�����N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Transform _deckPos;
    [SerializeField] CardController[] _cardPrefabs;
    [SerializeField] int _currentCoins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// �v���C���[�̃^�[���J�n���ɌĂԃJ�[�h����������
    /// </summary>
    public void TakeCard()
    {
        foreach(var card in _cardPrefabs)
        {
            CardController cc = Instantiate(card, _deckPos);
            cc.Init(card.Id);
        }
    }

    /// <summary>
    /// �v���C���[�̃^�[���I�����ɌĂ΂��J�[�h���폜���鏈��
    /// </summary>
    public void RemoveCards()
    {

    }
}
