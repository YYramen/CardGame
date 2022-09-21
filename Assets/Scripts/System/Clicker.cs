using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �N���b�N�������̂��擾����R���|�[�l���g
/// </summary>
public class Clicker : MonoBehaviour
{
    /// <summary>
    /// ���N���b�N�������̋���(�����N���b�N���������擾����)
    /// </summary>
    public void Click()
    {
        Debug.Log($"{this}�J�[�h�������ꂽ");
    }

    /// <summary>
    /// �h���b�O����
    /// </summary>
    public void Drag()
    {
        this.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// �J�[�h�𗣂�����
    /// </summary>
    public void Drop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDis = 100f;
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDis))
        {
            Debug.Log($"{hit.collider.name} �ɃJ�[�h��u����");
        }
    }
}
