using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToGameOver : ClickedBase
{

    private bool startEffect = false;

    private GameManager gameManager = null;

    public void Start()
    {
        //�e�I�u�W�F�N�g�Ɏ�����ǉ�
        BlockData blockData = transform.parent.GetComponent<BlockData>();
        if (blockData != null)
        {
            blockData.AddBlockInfo(gameObject, BlockData.BlockInfo.BlockType.Red);
        }

        if (!GameObject.Find("MetaObject").TryGetComponent(out gameManager))
        {
            Debug.LogError("GameManager��������܂���ł���");
        }
    }

    public override void GimmickClicked()
    {
        //�Q�[���I�[�o�[
        Debug.Log("GameOver");

        //�p�[�e�B�N���\��
        if (particleSystemComponent != null)
        {
            particleSystemComponent.Play();
            startEffect = true;
        }

        //SE�Đ�
        if (breakSE != null)
        {
            breakSE.Play();
        }

        //�����Ȃ��悤�ɂ��邽�߃����_���[������
        gameObject.GetComponent<Renderer>().enabled = false;

        //�����蔻�������
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (!startEffect) return;

        if (!particleSystemComponent.isPlaying)
        {
            //�Q�[���I�[�o�[����
            Debug.Log("GameOver����");

            if(gameManager != null)
            {
                gameManager.ExplotionGameOver();
            }
        }
    }


}
