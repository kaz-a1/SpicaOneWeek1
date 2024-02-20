using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckGoal : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform = null;

    [SerializeField] private GameObject playerObject = null;

    [SerializeField] private bool objectPos = false;

    [SerializeField] private float endBlockSpace = 0.0f;

    private float goalX = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        CalcGoalX();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            Debug.LogError("プレイヤーオブジェクトがアタッチされていません");
            return;
        }

        //ゴール地点が計算されていない場合(スタートだと上手く動かない)
        if(goalX == 0.0f)
        {
            CalcGoalX();
        }

        if (playerObject.transform.position.x > transform.position.x + goalX)
        {
            Debug.Log("ゴール");

            gameObject.AddComponent<CreateGameClear>().Create();
        }

    }

    //ゴール地点を計算
    private void CalcGoalX()
    {
        //オブジェクトの位置を使う場合
        if (objectPos)
        {
            goalX = transform.position.x;
            return;
        }

        //ステージの幅を使う場合
        if (rectTransform == null)
        {
            Debug.LogError("rectTransform がアタッチされていません");
            return;
        }

        goalX = rectTransform.rect.width;
        goalX += endBlockSpace;
    }
}
