using UnityEngine;
using UnityEngine.UI;

public class BackGroundMover : MonoBehaviour
{
    private const float k_maxLength = 1f;
    private const string k_propName = "_MainTex";

    [SerializeField]
    private float m_offsetSpeedX; // X�������̃I�t�Z�b�g���x

    private Material m_material;

    private void Start()
    {
        if (GetComponent<Image>() is Image i)
        {
            m_material = i.material; // Image�R���|�[�l���g����}�e���A�����擾
        }
    }

    private void Update()
    {
        if (m_material)
        {
            // X���̒l��0����1�͈̔͂Ń��[�v������
            var x = Mathf.Repeat(Time.time * m_offsetSpeedX, k_maxLength);
            var offset = new Vector2(x, 0f); // Y�������̃I�t�Z�b�g��0�ɌŒ�
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // �I�u�W�F�N�g���j�����ꂽ�ۂɁA�e�N�X�`���̃I�t�Z�b�g�����Z�b�g����
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}