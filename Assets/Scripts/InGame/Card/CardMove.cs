using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �N���b�N�������̂��擾����R���|�[�l���g
/// </summary>
public class CardMove : MonoBehaviour
{
    bool _isMove;
    public bool IsMove { get => _isMove; set => _isMove = value; }

    /// <summary>
    /// ���N���b�N�������̋���(�����N���b�N���������擾����)
    /// </summary>
    public void Click()
    {
        Debug.Log($"{this}�J�[�h���I�����ꂽ");
    }

    /// <summary>
    /// �h���b�O����
    /// </summary>
    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// �J�[�h�𗣂�����
    /// </summary>
    public void Drop()
    {
        Debug.Log($"{this} �J�[�h�𗣂���");

        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1), 100);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        
    }
}
