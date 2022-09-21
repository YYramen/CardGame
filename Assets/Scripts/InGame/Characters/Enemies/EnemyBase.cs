using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// “G‚ÌŠî’êƒNƒ‰ƒX
/// </summary>
public class EnemyBase : MonoBehaviour
{
    public void Excute(int id)
    {
        Move();
    }

    public virtual void Move()
    {
        Debug.Log($"{this} ‚ÌMoveŠÖ”‚ªŒÄ‚Î‚ê‚Ü‚µ‚½");
    }

    public virtual void Damage(int value)
    {
        Debug.Log($"{this} ‚ÌDamageŠÖ”‚ªŒÄ‚Î‚ê‚Ü‚µ‚½");
    }
}
