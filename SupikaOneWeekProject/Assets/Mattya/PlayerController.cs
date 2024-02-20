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
        // Awake ���\�b�h�ő��̃|�C���^���擾����Ǝ��̂�ꍇ�́A�K�v�ȏ�����ǉ�����awsd
    }

    void Start()
    {
        // BoxCollider2D �R���|�[�l���g���擾
        boxCollider = GetComponent<BoxCollider2D>();

        // �������́ABoxCollider2D �R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�́Anull ��Ԃ�
        if (boxCollider == null)
        {
            Debug.LogWarning("BoxCollider2D �R���|�[�l���g���A�^�b�`����Ă��܂���B");
        }

        // ���̃I�u�W�F�N�g�ɃA�N�Z�X���� BoxCollider2D �R���|�[�l���g���擾���鏈���� Start ���\�b�h���ōs�����Ƃ��ł��܂�
        GameObject otherObject = GameObject.Find("Square");
        if (otherObject != null)
        {
            BoxCollider2D otherCollider = otherObject.GetComponent<BoxCollider2D>();
            if (otherCollider == null)
            {
                Debug.LogWarning("OtherObject �� BoxCollider2D �R���|�[�l���g���A�^�b�`����Ă��܂���B");
            }
            else
            {
                Debug.Log("OtherObject �̒��S���W: " + otherCollider.bounds.center);
                Debug.Log("OtherObject �̃T�C�Y: " + otherCollider.bounds.size);
            }
        }
        else
        {
            Debug.LogWarning("OtherObject ��������܂���ł����B");
        }
    }

    void Update()
    {
        if (Deth)
        {
            //���S�A�j���[�V���������Ȃ炱��


            // Z���𒆐S�ɉ�]����
            transform.Rotate(Vector3.forward, 20 * Time.deltaTime);

            Vector3 newPosition = transform.position; // ���݂̈ʒu���擾

            newPosition.y -= 0.1f;
            newPosition.x -= 0.1f;

            transform.position = newPosition; // �V�����ʒu��ݒ�

            //�Q�[���I�[�o�[
            Debug.Log("GameOver");

            //gameObject.AddComponent<CreateGameOver>().Create();
        }
        else
        {
            Vector3 newPosition = transform.position; // ���݂̈ʒu���擾

            
            float AddMoveSpeed = moveSpeed;
            if (LeftAndRightMove)
            {
                //�����΂߈ړ����͂����Ă���Ȃ�
                if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) 
                    && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
                {
                    //�ړ��ʂ���2�ɂ���
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

            if (LeftAndRightMove)   //���E�ړ�����̂��ȁH
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

            transform.position = newPosition; // �V�����ʒu��ݒ�

            if (boxCollider != null)
            {
                // ���̃I�u�W�F�N�g�Ƃ̓����蔻������o
                Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0f);
                foreach (Collider2D collider in colliders)
                {
                    // ���g�ȊO�̃I�u�W�F�N�g�Ƃ̓����蔻������o
                    if (collider.gameObject != gameObject)
                    {
                        Deth = true;
                    }
                }
            }

        }
    }
    }