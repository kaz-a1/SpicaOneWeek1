using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToGameOver : ClickedBase
{

    protected override void GimmickClicked()
    {
        //継承先でクリックされた時の処理を書く
        Debug.Log("GameOver");
    }


}
