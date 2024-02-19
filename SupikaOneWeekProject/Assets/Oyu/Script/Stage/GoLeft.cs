using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{

    [SerializeField] private float speed = 0.1f;

    //�X�^�[�g����̎���(�b)
    [SerializeField] private float startToTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�X�^�[�g���Ԃ�0�̎��̍��W���v�Z
        float width = Camera.main.orthographicSize * 2 * 1920 / 1080;
        transform.position = new Vector3(width / 2.0f, 0, 0);

        //���Ԃ̕������E��
        transform.position += new Vector3(startToTime * speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //�f���^�^�C��
        float delta = Time.deltaTime;

        //�E�Ɉړ�
        transform.position += new Vector3(-speed * delta, 0, 0);
    }
}
