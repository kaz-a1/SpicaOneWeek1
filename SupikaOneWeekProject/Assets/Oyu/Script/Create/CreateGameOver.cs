using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameOver : MonoBehaviour
{

    public void Create()
    {
        //���[�ރI�[�o�[�̕������o��

        //(��)�^�C�g���֖߂�
        ToNextScene toNextScene = gameObject.AddComponent<ToNextScene>();
        toNextScene.SetNextSceneString("OyuTitleScene");
        toNextScene.LoadNextScene();

        Destroy(this);
    }

}
