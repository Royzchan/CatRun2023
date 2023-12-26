using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    // �ǂݍ��ރV�[����
    [SerializeField, Header("�^�C�g���V�[��")]
    public string TitleScene;

    [SerializeField,Header("���̃V�[����")]
    public string NextScene;

    //��\��
    [SerializeField, HideInInspector, Header("�u�X�e�[�W�I���v�̃V�[��")]
    private string selectsteageScene;


    //�S�[�����Ă���\�����遨���V�[���Ŏg��Ȃ����璼��
    [SerializeField, Header("�X�e�[�W�I��")]
    private GameObject SteageSelectButton;


    [SerializeField, Header("�V�[���ؑ֕b��")]
    private float SceneTime = 1.0f;

    void Start()
    {
        //�X�e�[�W�ؑ�
        selectsteageScene = "SelectSteage";

        //�ŏ��͕\��
       // SteageSelectButton.SetActive(false);
    }

    //�^�C�g��
    public void TitleLoad()
    {
        FadeManager.Instance.LoadScene(TitleScene, SceneTime);
    }

    public void SceneLoad()
    {
        //�V�[���ؑ�
        //SceneManager.LoadScene(sceneName);
        //nabichilab�t�@�C���g�p
        FadeManager.Instance.LoadScene(NextScene, SceneTime);
       // Debug.Log("Name" + sceneName);
    }

    //���g���C
    public void RetryLoad()
    {
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name, SceneTime);
    }

    //�ǂ����N���A������\�� 
    public void SelectStege()
    {
        //�{�^���\��
        //SteageSelectButton.SetActive(true);
        //�ؑ։����t�F�[�h
        FadeManager.Instance.LoadScene(selectsteageScene, SceneTime);
    }
}
