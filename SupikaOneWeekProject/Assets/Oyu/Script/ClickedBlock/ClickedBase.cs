using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedBase : MonoBehaviour
{

    [SerializeField] protected ParticleSystem particleSystemComponent = null;
    [SerializeField] protected AudioSource breakSE = null;

    // Start is called before the first frame update
    void Start()
    {
        //�e�I�u�W�F�N�g�Ɏ�����ǉ�
        BlockData blockData = transform.parent.GetComponent<BlockData>();
        if (blockData != null)
        {
            blockData.AddBlockInfo(gameObject,BlockData.BlockInfo.BlockType.Black);
        }
    }

    public virtual void GimmickClicked()
    {
        //�p����ŃN���b�N���ꂽ���̏���������
        
        //�p�[�e�B�N���\��
        if(particleSystemComponent != null)
        {
            particleSystemComponent.Play();
        }

        //SE�Đ�
        if(breakSE != null)
        {
            breakSE.Play();
        }

        //�����Ȃ��悤�ɂ��邽�߃����_���[������
        gameObject.GetComponent<Renderer>().enabled = false;

        //�����蔻�������
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void OnDestroy()
    {
        //������鎞�̏����@�u���b�N�ɂ���ĈႤ�̂ŃI�[�o�[���C�h���Ďg��
        //Debug.Log("OnDestroy");
    }

    void OnDisable()
    {
        //�}�E�X���I�u�W�F�N�g��ŃN���b�N���ꂽ�Ƃ��̏���
        //Debug.Log("OnDisable");
    }

    //�}�E�X���I�u�W�F�N�g��ŃN���b�N���ꂽ�Ƃ��̏���
    public void OnMouseDown()
    {
        //Update���~�܂��Ă���Ƃ��͏������Ȃ�
        if (!SceneUpdateManager.Instance.GetIsUpdate()) return;

        GimmickClicked();
    }
}
