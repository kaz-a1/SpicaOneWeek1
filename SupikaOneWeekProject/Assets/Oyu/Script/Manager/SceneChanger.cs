using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : SingletonMonoBehaviour<SceneChanger>
{
    public enum SceneName
    {
        Title,
        Game,
    }
    [SerializeField]
    private SerializableDictionary<SceneName, string> sceneList = null;

    private ToNextScene toNextScene;


}
