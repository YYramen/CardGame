using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private NodeType _type;

    private void Start()
    {
        _type = NodeType.Unsetting;        
    }
}
