using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoLeft : MonoBehaviour
{

    [SerializeField] private GridLayoutGroup gridLayoutGroup = null;

    [SerializeField] private float speed = 0.1f;

    //初めに画面内に入っているブロック数
    [SerializeField] private float startInBlock = 0;

    //スタートからの時間(秒)
    [NonSerialized] private float startToTime = 0.0f;

    private bool clacStartPos = false;


    // Start is called before the first frame update
    void Start()
    {
        //スタート時間が0の時の座標を計算
        float width = Camera.main.orthographicSize * 2 * 1920 / 1080;
        transform.position = new Vector3(width / 2.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //スタート位置を計算
        if (!clacStartPos)
        {
            CalcStartPos();
            clacStartPos = true;
        }

        //デルタタイム
        float delta = Time.deltaTime;

        //右に移動
        gameObject.transform.position += new Vector3(-speed * delta, 0, 0);
    }

    private void CalcStartPos()
    {
        //startToTime の分だけ右へ
        gameObject.transform.position += new Vector3(startToTime * speed, 0, 0);

        //初めに画面内に入っているブロック数分左へ
        if (gridLayoutGroup == null)
        {
            Debug.LogError("gridLayoutGroup がアタッチされていません");
            return;
        }
        gameObject.transform.position += new Vector3(-startInBlock * gridLayoutGroup.cellSize.x, 0, 0);

    }
}
