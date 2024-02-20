using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameClear : MonoBehaviour
{

    public void Create()
    {
        //げーむ終了の文字を出す

        //(仮)タイトルへ戻る
        ToNextScene toNextScene = gameObject.AddComponent<ToNextScene>();
        toNextScene.SetNextSceneString("OyuTitleScene");
        toNextScene.LoadNextScene();

        Destroy(this);
    }

}
