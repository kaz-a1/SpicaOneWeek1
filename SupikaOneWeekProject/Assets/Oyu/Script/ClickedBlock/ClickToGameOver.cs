using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToGameOver : ClickedBase
{

    private bool startEffect = false;

    private GameManager gameManager = null;

    public void Start()
    {
        //親オブジェクトに自分を追加
        BlockData blockData = transform.parent.GetComponent<BlockData>();
        if (blockData != null)
        {
            blockData.AddBlockInfo(gameObject, BlockData.BlockInfo.BlockType.Red);
        }

        if (!GameObject.Find("MetaObject").TryGetComponent(out gameManager))
        {
            Debug.LogError("GameManagerが見つかりませんでした");
        }
    }

    public override void GimmickClicked()
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

        //見えないようにするためレンダラーを消す
        gameObject.GetComponent<Renderer>().enabled = false;

        //当たり判定を消す
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (!startEffect) return;

        if (!particleSystemComponent.isPlaying)
        {
            //ゲームオーバー処理
            Debug.Log("GameOver処理");

            if(gameManager != null)
            {
                gameManager.ExplotionGameOver();
            }
        }
    }


}
