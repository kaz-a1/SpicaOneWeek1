using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameEnd : MonoBehaviour
{

    public void Create()
    {
        //���[�ޏI���̕������o��

        //(��)�^�C�g���֖߂�
        ToNextScene toNextScene = gameObject.AddComponent<ToNextScene>();
        toNextScene.SetNextSceneString("OyuTitleScene");
        toNextScene.LoadNextScene();

        Destroy(this);
    }

}
