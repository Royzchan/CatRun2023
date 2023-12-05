using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    //�v���C���[�̓����֌W
    [SerializeField, Header("�v���C���[�̈ړ����x")]
    private float _runSpeed = 5.0f;

    private float _startRunSpeed;

    [SerializeField, Header("�v���C���[�̃W�����v�̑���")]
    private float _jumpSpeed = 5.0f;

    [SerializeField, Header("�v���C���[�̃W�����v�ł����")]
    private int _canJumpNum = 2;

    [SerializeField, Header("�v���C���[���W�����v�ł��鍂��")]
    private float _canJumpHeight = 3.0f;

    //�W�����v�̎��Ɏg��������}��ׂ̕ϐ�
    private float _jumpStartPos = 0f;

    //�����邩�ǂ���
    private bool _canFloat = false;

    //�W�����v������(�J�E���g�p)
    private int _jumpNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _startRunSpeed = _runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ����x�𑖂��Ă���X�s�[�h�ɂ���
        rb.velocity = new Vector3(_runSpeed, rb.velocity.y, 0f);


        //�W�����v�̃{�^���������ꂽ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�W�����v�����񐔂��W�����v�ł���񐔂��Ⴉ������
            if(_jumpNum<_canJumpNum)
            {
                if (_jumpNum > 0)
                {
                    rb.velocity = Vector3.zero;
                }
                //�W�����v�̉񐔂𑫂���
                _jumpNum++;
                rb.AddForce(new Vector3(0f, _canJumpHeight, 0f),ForceMode.Impulse);
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�n�ʂɐG�ꂽ��
        if(collision.gameObject.CompareTag("Ground"))
        {
            _jumpNum = 0;
        }
    }
}
