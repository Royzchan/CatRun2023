using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SteageSelect : MonoBehaviour
{
#if �z��̃V�[���֖ؑ��g�p
    //�V�[���I��
    [SerializeField,Header("�X�e�[�W������")]
    private string[] Stages;
    public void SceneLoad()
    {
        //�V�[���ؑ�
        //SceneManager.LoadScene(sceneName);
        //nabichilab�t�@�C���g�p
        for (int i = 0; i < Stages.Length; i++)
        {
            FadeManager.Instance.LoadScene(Stages[i], 1);

        }
    }

#endif

    // �ǂݍ��ރV�[����
    [SerializeField, Header("�X�e�[�W�P")]
    public string scene1;
    [SerializeField, Header("�X�e�[�W�Q")]
    public string scene2;
    [SerializeField, Header("�X�e�[�W�R")]
    public string scene3;

    public void Stege1()
    {
        //�{�^���\��
        //SteageSelectButton.SetActive(true);
        //�ؑ։����t�F�[�h�Ȃ�
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

