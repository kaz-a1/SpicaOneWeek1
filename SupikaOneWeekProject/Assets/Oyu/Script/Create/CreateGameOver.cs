using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameOver : MonoBehaviour
{

    public void Create()
    {
        //げーむオーバーの文字を出す

        //(仮)タイトルへ戻る
        ToNextScene toNextScene = gameObject.AddComponent<ToNextScene>();
        toNextScene.SetNextSceneString("OyuTitleScene");
        toNextScene.LoadNextScene();

        Destroy(this);
    }

}
