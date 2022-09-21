using System.Linq;
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
    [SerializeField] List<CardController> _deckCards = new List<CardController> ();
    [SerializeField] List<CardController> _recycleCards = new List<CardController>();
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
        for(int i = 0; i < 5; i++)
        {
            CardController cc = Instantiate(_deckCards[i], _deckPos);
            cc.Init();
            Debug.Log($"�f�b�L����J�[�h���擾");
        }
    }

    /// <summary>
    /// �v���C���[�̃^�[���I�����ɌĂ΂��,�J�[�h���̂ăf�b�L�Ɉړ������鏈��
    /// </summary>
    public void RemoveCards()
    {
        GameObject[] cards = new GameObject[_deckCards.Count];
        
    }
}
