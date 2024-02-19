using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedBase : MonoBehaviour
{
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void OnDestroy()
    {
        //消される時の処理　ブロックによって違うのでオーバーライドして使う
        Debug.Log("Invok()");
    }

    //マウスがオブジェクト上でクリックされたときの処理
    public void OnMouseDown()
    {
        GameObject.Destroy(gameObject);
    }
}
