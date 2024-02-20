using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 0.1f;
    public bool LeftAndRightMove = false;
    private BoxCollider2D boxCollider;

    public bool Deth = false;

    void Awake()
    {
        // Awake メソッドで他のポインタを取得すると事故る場合は、必要な処理を追加するawsd
    }

    void Start()
    {
        // BoxCollider2D コンポーネントを取得
        boxCollider = GetComponent<BoxCollider2D>();

        // もしくは、BoxCollider2D コンポーネントがアタッチされていない場合は、null を返す
        if (boxCollider == null)
        {
            Debug.LogWarning("BoxCollider2D コンポーネントがアタッチされていません。");
        }

        // 他のオブジェクトにアクセスして BoxCollider2D コンポーネントを取得する処理も Start メソッド内で行うことができます
        GameObject otherObject = GameObject.Find("Square");
        if (otherObject != null)
        {
            BoxCollider2D otherCollider = otherObject.GetComponent<BoxCollider2D>();
            if (otherCollider == null)
            {
                Debug.LogWarning("OtherObject に BoxCollider2D コンポーネントがアタッチされていません。");
            }
            else
            {
                Debug.Log("OtherObject の中心座標: " + otherCollider.bounds.center);
                Debug.Log("OtherObject のサイズ: " + otherCollider.bounds.size);
            }
        }
        else
        {
            Debug.LogWarning("OtherObject が見つかりませんでした。");
        }
    }

    void Update()
    {
        if (Deth)
        {
            //死亡アニメーション入れるならここ


            // Z軸を中心に回転する
            transform.Rotate(Vector3.forward, 20 * Time.deltaTime);

            Vector3 newPosition = transform.position; // 現在の位置を取得

            newPosition.y -= 0.1f;
            newPosition.x -= 0.1f;

            transform.position = newPosition; // 新しい位置を設定

            //ゲームオーバー
            Debug.Log("GameOver");

            //gameObject.AddComponent<CreateGameOver>().Create();
        }
        else
        {
            Vector3 newPosition = transform.position; // 現在の位置を取得

            
            float AddMoveSpeed = moveSpeed;
            if (LeftAndRightMove)
            {
                //もし斜め移動入力をしているなら
                if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) 
                    && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
                {
                    //移動量を√2にする
                    AddMoveSpeed /= Mathf.Sqrt(2);
                }
            }
            Debug.Log(AddMoveSpeed);

            if (Input.GetKey(KeyCode.W))
            {
                newPosition.y += AddMoveSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                newPosition.y -= AddMoveSpeed;
            }

            if (LeftAndRightMove)   //左右移動あるのかな？
            {
                if (Input.GetKey(KeyCode.D))
                {
                    newPosition.x += AddMoveSpeed;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    newPosition.x -= AddMoveSpeed;
                }
            }

            transform.position = newPosition; // 新しい位置を設定

            if (boxCollider != null)
            {
                // 他のオブジェクトとの当たり判定を検出
                Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0f);
                foreach (Collider2D collider in colliders)
                {
                    // 自身以外のオブジェクトとの当たり判定を検出
                    if (collider.gameObject != gameObject)
                    {
                        Deth = true;
                    }
                }
            }

        }
    }
    }