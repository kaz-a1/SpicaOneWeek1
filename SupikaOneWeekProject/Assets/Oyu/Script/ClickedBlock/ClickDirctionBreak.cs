using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDirctionBreak : ClickedBase
{

    [SerializeField] private float speed = 0.01f;
    private GoLeft goLeft = null;
    private bool isMove = false;
    private bool once = false;

    [SerializeField] int moveBlockNum = 3;
    private float moveDistance = 0;
    private Vector3 targetPos = new Vector3();

    BlockData blockData;

    public override void GimmickClicked()
    {
        if (once) return;
        if (isMove) return;

        isMove = true;

        //コライダー2Dのトリガーをオフにする
        gameObject.GetComponent<Collider2D>().isTrigger = false;

        //rigidbodyを追加
        Rigidbody2D _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        if (blockData == null)
        {
            blockData = GameObject.Find("Blocks").GetComponent<BlockData>();
        }
        blockData.OutBlueBlock(gameObject);

        CalcTargetPos();
    }

    void Start()
    {
        if (blockData == null)
        {
            blockData = GameObject.Find("Blocks").GetComponent<BlockData>();
        }
        else
        {
            Debug.LogError("BlockDataが見つかりません");
        }

        if (!transform.parent.transform.parent.TryGetComponent<GoLeft>(out goLeft))
        {
            Debug.LogError("GoLeftが見つかりません");
        }

        CalcTargetPos();
    }

    void Update()
    {
        if (once) return;
        if (!isMove) return;

        //右に移動
        targetPos.x -= goLeft.GetSpeed() * Time.deltaTime;
        float move = (speed + goLeft.GetSpeed()) * Time.deltaTime;
        moveDistance -= move;
        if (moveDistance < 0)
        {
            transform.position = targetPos;
            Debug.Log($"transform.position:{transform.position}");
            isMove = false;
            once = true;
        }
        else
        {
            transform.position += new Vector3(-move, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other.transform.name} is OnTriggerEnter in Cube.");

        ClickedBase clicked = other.GetComponent<ClickedBase>();
        if (clicked == null) return;
        clicked.GimmickClicked();
    }

    private void CalcTargetPos()
    {
        if (blockData == null) return;

        //移動距離を計算
        GridLayoutGroup gridLayout = blockData.GetGridLayoutGroup();
        moveDistance = gridLayout.cellSize.x * moveBlockNum;

        //pivotのずれを考慮
        targetPos = new Vector3(transform.position.x - moveDistance, transform.position.y, 0);

        Debug.Log($"targetPos:{targetPos}");

    }

}
