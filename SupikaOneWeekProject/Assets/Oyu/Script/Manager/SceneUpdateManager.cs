using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//メニュー画面などでシーンを一時停止するためのクラス

public class SceneUpdateManager : SingletonMonoBehaviour<SceneUpdateManager>
{

    private bool isUpdate = true;
    bool GetIsUpdate()
    {
        return isUpdate;
    }

    public void StopUpdate()
    {
        //一時停止
        isUpdate = false;
        Time.timeScale = 0;
    }

    public void StartUpdate()
    {
        //再開
        isUpdate = true;
        Time.timeScale = 1;
    }
}
