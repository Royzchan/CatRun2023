using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    // 読み込むシーン名
    [SerializeField, Header("タイトルシーン")]
    public string TitleScene;

    [SerializeField,Header("次のシーン名")]
    public string NextScene;

    //非表示
    [SerializeField, HideInInspector, Header("「ステージ選択」のシーン")]
    private string selectsteageScene;


    //ゴールしてたら表示する→他シーンで使わないから直す
    [SerializeField, Header("ステージ選択")]
    private GameObject SteageSelectButton;


    [SerializeField, Header("シーン切替秒数")]
    private float SceneTime = 1.0f;

    void Start()
    {
        //ステージ切替
        selectsteageScene = "SelectSteage";

        //最初は表示
       // SteageSelectButton.SetActive(false);
    }

    //タイトル
    public void TitleLoad()
    {
        FadeManager.Instance.LoadScene(TitleScene, SceneTime);
    }

    public void SceneLoad()
    {
        //シーン切替
        //SceneManager.LoadScene(sceneName);
        //nabichilabファイル使用
        FadeManager.Instance.LoadScene(NextScene, SceneTime);
       // Debug.Log("Name" + sceneName);
    }

    //リトライ
    public void RetryLoad()
    {
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name, SceneTime);
    }

    //どこかクリアしたら表示 
    public void SelectStege()
    {
        //ボタン表示
        //SteageSelectButton.SetActive(true);
        //切替仮→フェード
        FadeManager.Instance.LoadScene(selectsteageScene, SceneTime);
    }
}
