using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedBase : MonoBehaviour
{
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void OnDestroy()
    {
        //������鎞�̏����@�u���b�N�ɂ���ĈႤ�̂ŃI�[�o�[���C�h���Ďg��
        Debug.Log("Invok()");
    }

    //�}�E�X���I�u�W�F�N�g��ŃN���b�N���ꂽ�Ƃ��̏���
    public void OnMouseDown()
    {
        GameObject.Destroy(gameObject);
    }
}
