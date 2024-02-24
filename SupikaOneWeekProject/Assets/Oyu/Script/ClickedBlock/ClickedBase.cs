using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedBase : MonoBehaviour
{

    [SerializeField] protected ParticleSystem particleSystemComponent = null;
    [SerializeField] protected AudioSource breakSE = null;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトに自分を追加
        BlockData blockData = transform.parent.GetComponent<BlockData>();
        if (blockData != null)
        {
            blockData.AddBlockInfo(gameObject,BlockData.BlockInfo.BlockType.Black);
        }
    }

    public virtual void GimmickClicked()
    {
        //継承先でクリックされた時の処理を書く
        
        //パーティクル表示
        if(particleSystemComponent != null)
        {
            particleSystemComponent.Play();
        }

        //SE再生
        if(breakSE != null)
        {
            breakSE.Play();
        }

        //見えないようにするためレンダラーを消す
        gameObject.GetComponent<Renderer>().enabled = false;

        //当たり判定を消す
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void OnDestroy()
    {
        //消される時の処理　ブロックによって違うのでオーバーライドして使う
        //Debug.Log("OnDestroy");
    }

    void OnDisable()
    {
        //マウスがオブジェクト上でクリックされたときの処理
        //Debug.Log("OnDisable");
    }

    //マウスがオブジェクト上でクリックされたときの処理
    public void OnMouseDown()
    {
        //Updateが止まっているときは処理しない
        if (!SceneUpdateManager.Instance.GetIsUpdate()) return;

        GimmickClicked();
    }
}
