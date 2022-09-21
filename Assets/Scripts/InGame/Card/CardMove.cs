using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// クリックしたものを取得するコンポーネント
/// </summary>
public class CardMove : MonoBehaviour
{
    Transform _prevPos;

    /// <summary>
    /// 左クリックした時の挙動(何をクリックしたかを取得する)
    /// </summary>
    public void Click()
    {
        //_prevPos.transform.position = this.transform.position;
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
        if (hit.collider.CompareTag("Enemy"))
        {
            Debug.Log($"敵にダメージ");
            Debug.Log(hit.collider.gameObject.name);
            Destroy(gameObject);
        }
        else if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("味方に付与");
            Debug.Log(hit.collider.gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("none");
        }

        //this.transform.position = _prevPos.transform.position;
        //Debug.Log("何にも持って行かなかったためデッキに戻しました");

    }
}
