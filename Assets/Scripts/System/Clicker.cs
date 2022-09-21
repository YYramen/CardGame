using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリックしたものを取得するコンポーネント
/// </summary>
public class Clicker : MonoBehaviour
{
    /// <summary>
    /// 左クリックした時の挙動(何をクリックしたかを取得する)
    /// </summary>
    public void Click()
    {
        Debug.Log($"{this}カードが押された");
    }

    /// <summary>
    /// ドラッグする
    /// </summary>
    public void Drag()
    {
        this.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// カードを離した時
    /// </summary>
    public void Drop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDis = 100f;
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDis))
        {
            Debug.Log($"{hit.collider.name} にカードを置いた");
        }
    }
}
