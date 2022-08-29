using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : CardBase
{
    [SerializeField] int _def = 1;
    public override void OnExcute()
    {
        Debug.Log($"Defence: {_def}");
    }
}
