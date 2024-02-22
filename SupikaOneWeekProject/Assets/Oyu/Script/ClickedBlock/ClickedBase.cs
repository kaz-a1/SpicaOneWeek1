using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedBase : MonoBehaviour
{

    [SerializeField] protected ParticleSystem particleSystemComponent = null;
    [SerializeField] protected AudioSource breakSE = null;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void GimmickClicked()
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
        GimmickClicked();
       
        //見えないようにするためレンダラーを消す
        gameObject.GetComponent<Renderer>().enabled = false;

        //当たり判定を消す
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
