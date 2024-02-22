using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ClickToGameOver : ClickedBase
{

    private bool startEffect = false;

    protected override void GimmickClicked()
    {
        //ゲームオーバー
        Debug.Log("GameOver");

        //パーティクル表示
        if (particleSystemComponent != null)
        {
            particleSystemComponent.Play();
            startEffect = true;
        }

        //SE再生
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
            //ゲームオーバー処理
            Debug.Log("GameOver処理");
            gameObject.AddComponent<CreateGameOver>().Create();
        }


    }


}
