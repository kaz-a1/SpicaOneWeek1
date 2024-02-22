using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ClickToGameOver : ClickedBase
{

    private bool startEffect = false;

    protected override void GimmickClicked()
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
    }

    void Update()
    {

        if (!startEffect) return;

        if (!particleSystemComponent.isPlaying)
        {
            //�Q�[���I�[�o�[����
            Debug.Log("GameOver����");
            gameObject.AddComponent<CreateGameOver>().Create();
        }


    }


}
