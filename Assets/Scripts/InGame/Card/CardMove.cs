using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// クリックしたものを取得するコンポーネント
/// </summary>
public class CardMove : MonoBehaviour
{
    bool _isMove;
    public bool IsMove { get => _isMove; set => _isMove = value; }

    /// <summary>
    /// 左クリックした時の挙動(何をクリックしたかを取得する)
    /// </summary>
    public void Click()
    {
        Debug.Log($"{this}カードが選択された");
    }

    /// <summary>
    /// ドラッグする
    /// </summary>
    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// カードを離した時
    /// </summary>
    public void Drop()
    {
        Debug.Log($"{this} カードを離した");

        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1), 100);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        
    }
}
