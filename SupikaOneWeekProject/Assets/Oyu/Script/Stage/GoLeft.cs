using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{

    [SerializeField] private float speed = 0.1f;

    //スタートからの時間(秒)
    [SerializeField] private float startToTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //スタート時間が0の時の座標を計算
        float width = Camera.main.orthographicSize * 2 * 1920 / 1080;
        transform.position = new Vector3(width / 2.0f, 0, 0);

        //時間の分だけ右へ
        transform.position += new Vector3(startToTime * speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //デルタタイム
        float delta = Time.deltaTime;

        //右に移動
        transform.position += new Vector3(-speed * delta, 0, 0);
    }
}
