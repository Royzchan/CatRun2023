using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("ゲームが始まるまでの時間")]
    private float _startTime = 3.0f;

    private bool _gameNow = false;

    [SerializeField]
    private PlayerController _playerController;

    [SerializeField, Header("カウントダウンのUI")]
    private GameObject[] _countdownImages;

    //タイマー関係
    public static float _clearTime = 0;

    //クリアされた時に呼び出される関数
    public void gameClear()
    {
        _gameNow = false;
        Invoke(nameof(goResult), 1.0f);
    }

    void goResult()
    {
        SceneManager.LoadScene("ResultScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        _clearTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_clearTime);
        float deltaTime=Time.deltaTime;

        if (_startTime >= 0)
        {
            _startTime -= deltaTime;

            if (_startTime >= 2)
            {
                _countdownImages[0].SetActive(true);
            }
            else if (_startTime >= 1)
            {
                _countdownImages[1].SetActive(true);
                _countdownImages[0].SetActive(false);
            }
            else if(_startTime >= 0)
            {
                _countdownImages[2].SetActive(true);
                _countdownImages[1].SetActive(false);
            }
            else if (_startTime<=0)
            {
                _countdownImages[3].SetActive(true);
                _countdownImages[2].SetActive(false);
                _gameNow = true;
                _playerController.RunStart();
            }
        }

        //ゲームがプレイ中だった場合に時間を足していく
        if(_gameNow)
        {
            _clearTime+=deltaTime;
        }
    }
}
