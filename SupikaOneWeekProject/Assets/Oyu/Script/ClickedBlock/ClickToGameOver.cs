using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToGameOver : ClickedBase
{

    protected override void GimmickClicked()
    {
        //ゲームオーバー
        Debug.Log("GameOver");

        gameObject.AddComponent<CreateGameOver>().Create();
    }


}
