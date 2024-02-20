using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLeft : MonoBehaviour
{

    [SerializeField] private GridLayoutGroup gridLayoutGroup = null;

    [SerializeField] private float speed = 0.1f;

    //���߂ɉ�ʓ��ɓ����Ă���u���b�N��
    [SerializeField] private float startInBlock = 0;

    //�X�^�[�g����̎���(�b)
    [NonSerialized] private float startToTime = 0.0f;

    private bool clacStartPos = false;


    // Start is called before the first frame update
    void Start()
    {
        //�X�^�[�g���Ԃ�0�̎��̍��W���v�Z
        float width = Camera.main.orthographicSize * 2 * 1920 / 1080;
        transform.position = new Vector3(width / 2.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //�X�^�[�g�ʒu���v�Z
        if (!clacStartPos)
        {
            CalcStartPos();
            clacStartPos = true;
        }

        //�f���^�^�C��
        float delta = Time.deltaTime;

        //�E�Ɉړ�
        gameObject.transform.position += new Vector3(-speed * delta, 0, 0);
    }

    private void CalcStartPos()
    {
        //startToTime �̕������E��
        gameObject.transform.position += new Vector3(startToTime * speed, 0, 0);

        //���߂ɉ�ʓ��ɓ����Ă���u���b�N��������
        if (gridLayoutGroup == null)
        {
            Debug.LogError("gridLayoutGroup ���A�^�b�`����Ă��܂���");
            return;
        }
        gameObject.transform.position += new Vector3(-startInBlock * gridLayoutGroup.cellSize.x, 0, 0);

    }
}
