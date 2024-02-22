using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//���j���[��ʂȂǂŃV�[�����ꎞ��~���邽�߂̃N���X

public class SceneUpdateManager : SingletonMonoBehaviour<SceneUpdateManager>
{

    private bool isUpdate = true;
    bool GetIsUpdate()
    {
        return isUpdate;
    }

    public void StopUpdate()
    {
        //�ꎞ��~
        isUpdate = false;
        Time.timeScale = 0;
    }

    public void StartUpdate()
    {
        //�ĊJ
        isUpdate = true;
        Time.timeScale = 1;
    }
}
