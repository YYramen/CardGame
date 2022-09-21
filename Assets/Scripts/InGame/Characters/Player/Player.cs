using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̋����𐧌䂷��R���|�[�l���g
/// </summary>
[Serializable]
public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("HP")] int _hp = 20;
    public int HP => _hp;

    [SerializeField, Tooltip("�V�[���h�l")] int _shield = 0;
    public int Shield => _shield;

    [SerializeField, Tooltip("���݂̃R�X�g")] byte _currentCost = 0;
    public byte CurrentCost => _currentCost;

    [SerializeField, Tooltip("���݂̃R�X�g")] byte _maxCost = 3;
    public byte MaxCost => _maxCost;
    [SerializeField] Text _costText;

    [SerializeField, Tooltip("������")] int _money;
    public int Money => _money;

    private void Update()
    {
        _costText.text = $"{_currentCost} / {_maxCost}";
    }

    public void ResetCost()
    {
        _currentCost = _maxCost;
        Debug.Log("�R�X�g�����Z�b�g����܂���");
    }

    public void Buff(int value)
    {
        _shield += value;
        Debug.Log("�V�[���h���t�^����܂���");
    }

    public void TakeDamage(int value)
    {
        _hp -= value;
        Debug.Log("�v���C���[���_���[�W���󂯂܂���");
    }
}
