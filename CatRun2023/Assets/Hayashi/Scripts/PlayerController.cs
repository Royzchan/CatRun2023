using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    //プレイヤーの動き関係
    [SerializeField, Header("プレイヤーの移動速度")]
    private float _runSpeed = 5.0f;

    private float _startRunSpeed;

    [SerializeField, Header("プレイヤーのジャンプの速さ")]
    private float _jumpSpeed = 5.0f;

    [SerializeField, Header("プレイヤーのジャンプできる回数")]
    private int _canJumpNum = 2;

    [SerializeField, Header("プレイヤーがジャンプできる高さ")]
    private float _canJumpHeight = 3.0f;

    //ジャンプの時に使う高さを図る為の変数
    private float _jumpStartPos = 0f;

    //浮けるかどうか
    private bool _canFloat = false;

    //ジャンプした回数(カウント用)
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
        //移動速度を走っているスピードにする
        rb.velocity = new Vector3(_runSpeed, rb.velocity.y, 0f);


        //ジャンプのボタンが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ジャンプした回数がジャンプできる回数より低かった時
            if(_jumpNum<_canJumpNum)
            {
                if (_jumpNum > 0)
                {
                    rb.velocity = Vector3.zero;
                }
                //ジャンプの回数を足して
                _jumpNum++;
                rb.AddForce(new Vector3(0f, _canJumpHeight, 0f),ForceMode.Impulse);
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //地面に触れたら
        if(collision.gameObject.CompareTag("Ground"))
        {
            _jumpNum = 0;
        }
    }
}
