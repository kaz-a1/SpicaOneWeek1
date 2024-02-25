using UnityEngine;
using UnityEngine.UI;

public class BackGroundMover : MonoBehaviour
{
    private const float k_maxLength = 1f;
    private const string k_propName = "_MainTex";

    [SerializeField]
    private float m_offsetSpeedX; // X軸方向のオフセット速度

    private Material m_material;

    private void Start()
    {
        if (GetComponent<Image>() is Image i)
        {
            m_material = i.material; // Imageコンポーネントからマテリアルを取得
        }
    }

    private void Update()
    {
        if (m_material)
        {
            // X軸の値を0から1の範囲でループさせる
            var x = Mathf.Repeat(Time.time * m_offsetSpeedX, k_maxLength);
            var offset = new Vector2(x, 0f); // Y軸方向のオフセットは0に固定
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // オブジェクトが破棄された際に、テクスチャのオフセットをリセットする
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}