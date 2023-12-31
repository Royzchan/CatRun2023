using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField,Header("ゲームマネージャー")]
    private GameManager gameManager;

    //プレイヤーの動き関係
    [SerializeField, Header("プレイヤーの移動速度")]
    private float _runSpeed = 5.0f;

    //走り出した時のスピード
    private float _startRunSpeed;

    [SerializeField, Header("プレイヤーのジャンプの速さ")]
    private float _jumpSpeed = 5.0f;

    [SerializeField, Header("プレイヤーのジャンプできる回数")]
    private int _canJumpNum = 2;

    [SerializeField, Header("プレイヤーがジャンプできる高さ")]
    private float _canJumpHeight = 3.0f;

    [SerializeField, Header("ノックバックする強さ")]
    private float _knockbackPower = 5.0f;

    //ノックバックするかどうか
    private bool _canKnockback = false; 

    //現在ノックバック中かどうか
    private bool _knockbackNow = false;

    //ジャンプの時に使う高さを図る為の変数
    private float _jumpStartPos = 0f;

    //ジャンプした回数(カウント用)
    private int _jumpNum = 0;

    //現在走っているかどうか
    private bool _runningNow = false;


    //ここからアニメーション用

    private Animator _playerAnim;
    private string isCrouching = "isCrouching";
    private string isJump = "isJump";
    private string onGround = "onGround";


    // Start is called before the first frame update

    //リスを走り始めさせる関数
    public void RunStart()
    {
        _runningNow = true;
    }

    //リスを止める
    public void RunStop()
    {
        _runningNow = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _startRunSpeed = _runSpeed;
        _playerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //走り始めるデバック
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            RunStart();
        }

        _playerAnim.SetBool(isJump, false);
        //現在の座標から前にレイを飛ばす飛ばす
        //今回は向いている方向の都合上、フォワードにマイナスをかける
        Ray Forwardray = new Ray(this.transform.position - new Vector3(0f, 0.3f, 0f), this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(Forwardray,　out hit, 1.0f))
        {
            //レイの当たったオブジェクトが木だった場合
            if(hit.collider.gameObject.CompareTag("Wood"))
            {
                //ノックバックできる判定をtrueにする
                _canKnockback = true;
            }
        }
        else
        {
            //レイに何も当たっていなかったらノックバックする判定をfalseにする
            _canKnockback = false;
        }

        //走っている判定がtrueだった場合は走る
        if(_runningNow)
        {
            //ノックバック中じゃなかった場合
            if (!_knockbackNow)
            {
                //移動速度を走っているスピードにする
                rb.velocity = new Vector3(_runSpeed, rb.velocity.y, 0f);
            }
        }
        //それ以外は止まる
        else
        {
            rb.velocity = Vector3.zero;
        }

        //ジャンプのボタンが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ジャンプした回数がジャンプできる回数より低かった時
            if(_jumpNum<_canJumpNum)
            {
                //二段ジャンプの前にかかっている力を消す
                if (_jumpNum > 0)
                {
                    rb.velocity = Vector3.zero;
                }
                //ジャンプの回数を足して
                _jumpNum++;
                //上に力を加える
                rb.AddForce(new Vector3(0f, _canJumpHeight, 0f),ForceMode.Impulse);
                _playerAnim.SetBool(isJump, true);
                _playerAnim.SetBool(onGround, false);
            }
        }

        //しゃがみボタンが押されたらしゃがみに
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _playerAnim.SetBool(isCrouching, true);
        }

        //しゃがみボタンが離されたら状態を戻す
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _playerAnim.SetBool(isCrouching, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            gameManager.gameClear();
            RunStop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //地面に触れたら
        if(collision.gameObject.CompareTag("Ground"))
        {
            _jumpNum = 0;
            _knockbackNow = false;
            _playerAnim.SetBool(isJump, false);
            _playerAnim.SetBool(onGround, true);
        }

        //木に触れたら
        if (collision.gameObject.CompareTag("Wood"))
        {
            //ノックバックできる判定がtrue(正面に木がある状態)
            if(_canKnockback)
            {
                //ノックバックしている判定をtrueにする
                _knockbackNow = true;
                //かかっている力を消す
                rb.velocity = Vector3.zero;
                //後ろと上に力を加える
                rb.AddForce(new Vector3(-_knockbackPower, 3f, 0f), ForceMode.Impulse);
            }
        }
    }
}
