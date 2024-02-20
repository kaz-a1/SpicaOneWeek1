using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckGoal : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform = null;

    [SerializeField] private GameObject playerObject = null;

    [SerializeField] private bool objectPos = false;

    [SerializeField] private float endBlockSpace = 0.0f;

    private float goalX = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        CalcGoalX();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            Debug.LogError("�v���C���[�I�u�W�F�N�g���A�^�b�`����Ă��܂���");
            return;
        }

        //�S�[���n�_���v�Z����Ă��Ȃ��ꍇ(�X�^�[�g���Ə�肭�����Ȃ�)
        if(goalX == 0.0f)
        {
            CalcGoalX();
        }

        if (playerObject.transform.position.x > transform.position.x + goalX)
        {
            Debug.Log("�S�[��");

            gameObject.AddComponent<CreateGameClear>().Create();
        }

    }

    //�S�[���n�_���v�Z
    private void CalcGoalX()
    {
        //�I�u�W�F�N�g�̈ʒu���g���ꍇ
        if (objectPos)
        {
            goalX = transform.position.x;
            return;
        }

        //�X�e�[�W�̕����g���ꍇ
        if (rectTransform == null)
        {
            Debug.LogError("rectTransform ���A�^�b�`����Ă��܂���");
            return;
        }

        goalX = rectTransform.rect.width;
        goalX += endBlockSpace;
    }
}
