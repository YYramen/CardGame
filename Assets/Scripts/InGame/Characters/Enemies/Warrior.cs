using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G(��m)�̃N���X, EnemyBase���p�����Ă���
/// </summary>
public class Warrior : EnemyBase
{
    [SerializeField] int _hp = 15;
    [SerializeField] int _atk = 5;
    [SerializeField] int _def = 5;

    public override void Move()
    {
        base.Move();
        Debug.Log($"{this} �������Ă���");
    }

    public override void Damage(int value)
    {
        _hp -= value;
    }
}
