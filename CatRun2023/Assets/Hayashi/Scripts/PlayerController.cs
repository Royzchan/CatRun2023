using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    //�v���C���[�̓����֌W
    [SerializeField, Header("�v���C���[�̈ړ����x")]
    private float _runSpeed = 5.0f;

    //����o�������̃X�s�[�h
    private float _startRunSpeed;

    [SerializeField, Header("�v���C���[�̃W�����v�̑���")]
    private float _jumpSpeed = 5.0f;

    [SerializeField, Header("�v���C���[�̃W�����v�ł����")]
    private int _canJumpNum = 2;

    [SerializeField, Header("�v���C���[���W�����v�ł��鍂��")]
    private float _canJumpHeight = 3.0f;

    [SerializeField, Header("�m�b�N�o�b�N���鋭��")]
    private float _knockbackPower = 5.0f;

    //�m�b�N�o�b�N���邩�ǂ���
    private bool _canKnockback = false; 

    //���݃m�b�N�o�b�N�����ǂ���
    private bool _knockbackNow = false;

    //�W�����v�̎��Ɏg��������}��ׂ̕ϐ�
    private float _jumpStartPos = 0f;

    //�W�����v������(�J�E���g�p)
    private int _jumpNum = 0;


    //��������A�j���[�V�����p

    private Animator _playerAnim;
    private string isCrouching = "isCrouching";


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _startRunSpeed = _runSpeed;
        _playerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //���݂̍��W����O�Ƀ��C���΂���΂�
        //����͌����Ă�������̓s����A�t�H���[�h�Ƀ}�C�i�X��������
        Ray Forwardray = new Ray(this.transform.position - new Vector3(0f, 0.3f, 0f), -this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(Forwardray, out hit, 1.0f))
        {
            //���C�̓��������I�u�W�F�N�g���؂������ꍇ
            if(hit.collider.gameObject.CompareTag("Wood"))
            {
                //�m�b�N�o�b�N�ł��锻���true�ɂ���
                _canKnockback = true;
            }
        }
        else
        {
            //���C�ɉ����������Ă��Ȃ�������m�b�N�o�b�N���锻���false�ɂ���
            _canKnockback = false;
        }


        //Debug.DrawRay(Forwardray.origin, Forwardray.direction , Color.red, 0.5f);
        //�m�b�N�o�b�N������Ȃ������ꍇ
        if (!_knockbackNow)
        {
            //�ړ����x�𑖂��Ă���X�s�[�h�ɂ���
            rb.velocity = new Vector3(_runSpeed, rb.velocity.y, 0f);
        }


        //�W�����v�̃{�^���������ꂽ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�W�����v�����񐔂��W�����v�ł���񐔂��Ⴉ������
            if(_jumpNum<_canJumpNum)
            {
                //��i�W�����v�̑O�ɂ������Ă���͂�����
                if (_jumpNum > 0)
                {
                    rb.velocity = Vector3.zero;
                }
                //�W�����v�̉񐔂𑫂���
                _jumpNum++;
                //��ɗ͂�������
                rb.AddForce(new Vector3(0f, _canJumpHeight, 0f),ForceMode.Impulse);
            }
        }

        //���Ⴊ�݃{�^���������ꂽ�炵�Ⴊ�݂�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _playerAnim.SetBool(isCrouching, true);
        }

        //���Ⴊ�݃{�^���������ꂽ���Ԃ�߂�
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _playerAnim.SetBool(isCrouching, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�n�ʂɐG�ꂽ��
        if(collision.gameObject.CompareTag("Ground"))
        {
            _jumpNum = 0;
            _knockbackNow = false;
        }

        //�؂ɐG�ꂽ��
        if (collision.gameObject.CompareTag("Wood"))
        {
            //�m�b�N�o�b�N�ł��锻�肪true(���ʂɖ؂�������)
            if(_canKnockback)
            {
                //�m�b�N�o�b�N���Ă��锻���true�ɂ���
                _knockbackNow = true;
                //�������Ă���͂�����
                rb.velocity = Vector3.zero;
                //���Ə�ɗ͂�������
                rb.AddForce(new Vector3(-_knockbackPower, 3f, 0f), ForceMode.Impulse);
            }
        }
    }
}
