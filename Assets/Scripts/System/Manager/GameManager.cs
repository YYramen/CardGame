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
    [SerializeField] List<CardController> _deckCards = new List<CardController>();
    [SerializeField] List<CardController> _recycleCards = new List<CardController>();

    [SerializeField] Player _player;

    [SerializeField] List<Warrior> _enemies = new List<Warrior>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    /// <summary>
    /// �v���C���[�̃^�[���J�n���ɌĂԃR�X�g�����Z�b�g���鏈��
    /// </summary>
    public void RefillCost()
    {
        _player.ResetCost();
    }

    /// <summary>
    /// �v���C���[�̃^�[���J�n���ɌĂԃJ�[�h����������
    /// </summary>
    public void TakeCard()
    {
        for (int i = 0; i < 5; i++)
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
        for (int i = 0; i < _deckCards.Count; i++)
        {
            _recycleCards.Add(_deckCards[i]);
        }

        foreach (Transform card in _deckPos.transform)
        {
            Destroy(card.gameObject);
        }
        Debug.Log("�J�[�h���̂ĎD�Ɉړ����܂���");
    }
}
