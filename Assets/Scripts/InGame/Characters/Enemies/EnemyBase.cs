using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̊��N���X
/// </summary>
public class EnemyBase : MonoBehaviour
{
    public void Excute(int id)
    {
        Move();
    }

    public virtual void Move()
    {
        Debug.Log($"{this} ��Move�֐����Ă΂�܂���");
    }

    public virtual void Damage(int value)
    {
        Debug.Log($"{this} ��Damage�֐����Ă΂�܂���");
    }
}
