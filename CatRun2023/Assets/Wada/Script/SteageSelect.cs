using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SteageSelect : MonoBehaviour
{
#if 配列のシーン切替未使用
    //シーン選択
    [SerializeField,Header("ステージ数入力")]
    private string[] Stages;
    public void SceneLoad()
    {
        //シーン切替
        //SceneManager.LoadScene(sceneName);
        //nabichilabファイル使用
        for (int i = 0; i < Stages.Length; i++)
        {
            FadeManager.Instance.LoadScene(Stages[i], 1);

        }
    }

#endif

    // 読み込むシーン名
    [SerializeField, Header("ステージ１")]
    public string scene1;
    [SerializeField, Header("ステージ２")]
    public string scene2;
    [SerializeField, Header("ステージ３")]
    public string scene3;

    public void Stege1()
    {
        //ボタン表示
        //SteageSelectButton.SetActive(true);
        //切替仮→フェードなう
        FadeManager.Instance.LoadScene(scene1, 1);
    }
    public void Stege2()
    {
         FadeManager.Instance.LoadScene(scene2, 1);
    }
    public void Stege3()
    {
         FadeManager.Instance.LoadScene(scene3, 1);
    }
}

