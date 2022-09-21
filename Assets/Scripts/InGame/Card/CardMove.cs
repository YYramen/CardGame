using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �N���b�N�������̂��擾����R���|�[�l���g
/// </summary>
public class CardMove : MonoBehaviour
{
    Transform _prevPos;

    /// <summary>
    /// ���N���b�N�������̋���(�����N���b�N���������擾����)
    /// </summary>
    public void Click()
    {
        //_prevPos.transform.position = this.transform.position;
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
        if (hit.collider.CompareTag("Enemy"))
        {
            Debug.Log($"�G�Ƀ_���[�W");
            Debug.Log(hit.collider.gameObject.name);
            Destroy(gameObject);
        }
        else if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("�����ɕt�^");
            Debug.Log(hit.collider.gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("none");
        }

        //this.transform.position = _prevPos.transform.position;
        //Debug.Log("���ɂ������čs���Ȃ��������߃f�b�L�ɖ߂��܂���");

    }
}
