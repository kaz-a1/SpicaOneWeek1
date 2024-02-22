using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    public void SetNextSceneString(string nextSceneName)
    {
        this.nextSceneName = nextSceneName;
    }

    [SerializeField] private string nextSceneName = "OyuGameScene";

    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        SceneUpdateManager.Instance.StartUpdate();
    }
}
