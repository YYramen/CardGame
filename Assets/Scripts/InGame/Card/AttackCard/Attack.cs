using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CardBase
{
    [SerializeField] int _atk = 1;
    public override void OnExcute()
    {
        Debug.Log($"Attack: {_atk}");
    }
}
