using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の基底クラス
/// </summary>
public class EnemyBase : MonoBehaviour
{
    public void Excute(int id)
    {
        Move();
    }

    public virtual void Move()
    {
        Debug.Log($"{this} のMove関数が呼ばれました");
    }

    public virtual void TakeDamage(int value)
    {
        Debug.Log($"{this} のDamage関数が呼ばれました");
    }
}
