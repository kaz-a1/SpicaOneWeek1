using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameClear : MonoBehaviour
{

    public void Create()
    {
        //���[�ޏI���̕������o��

        //(��)�^�C�g���֖߂�
        ToNextScene toNextScene = gameObject.AddComponent<ToNextScene>();
        toNextScene.LoadNextScene(ToNextScene.SceneName.Title);

        Destroy(this);
    }

}
