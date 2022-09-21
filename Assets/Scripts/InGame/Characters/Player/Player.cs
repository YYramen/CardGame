using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̋����𐧌䂷��R���|�[�l���g
/// </summary>
[Serializable]
public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("HP")] int _hp = 20;
    public int HP => _hp;

    [SerializeField, Tooltip("�R�X�g")] byte cost = 3;

    [SerializeField, Tooltip("������")] int _money;
    public int Money => _money;
    
}
