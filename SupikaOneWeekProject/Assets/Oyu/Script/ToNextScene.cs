using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    public enum SceneName
    {
        Title,
        Game,
    }
    private SerializableDictionary<SceneName, string> sceneList = null;

    [SerializeField] private SceneName nextScene = SceneName.Title;

    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneList[nextScene]);
    }

    public void LoadNextScene(SceneName sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneList[sceneName]);
    }

    private void Start()
    {
        sceneList = new SerializableDictionary<SceneName, string>();
        
        sceneList.Add(SceneName.Title, "TitleScene");
        sceneList.Add(SceneName.Game, "GameScene");

    }
}


[Serializable]
public class SerializableDictionary<TKey, TValue> :
    Dictionary<TKey, TValue>,
    ISerializationCallbackReceiver
{
    [Serializable]
    public class Pair
    {
        public TKey key = default;
        public TValue value = default;

        /// <summary>
        /// Pair
        /// </summary>
        public Pair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }

    [SerializeField]
    private List<Pair> _list = null;

    /// <summary>
    /// OnAfterDeserialize
    /// </summary>
    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        Clear();
        foreach (Pair pair in _list)
        {
            if (ContainsKey(pair.key))
            {
                continue;
            }
            Add(pair.key, pair.value);
        }
    }

    /// <summary>
    /// OnBeforeSerialize
    /// </summary>
    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        // èàóùÇ»Çµ
    }
}