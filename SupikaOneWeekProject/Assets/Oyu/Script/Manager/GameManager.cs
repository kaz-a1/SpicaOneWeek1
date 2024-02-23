using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    [SerializeField] private GameObject player;

    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    private bool isPauseMove = false;//�ρ[���A�j���[�V��������
    private GameObject pauseObject = null;
    private GameObject expGameoverObject = null;
    private GameObject dethGameoverObject = null;

    //�Q�[���̏��
    enum GameState
    {
        OtherGameScene,//�Q�[���V�[���ȊO

        Game,

        Pause,
        PauseMove,
        GameOver,
        GameClear,
    }
    [SerializeField] private GameState state = GameState.Game;

    public void Start()
    {
        SettingObjects();
    }

    public void Update()
    {
        SettingObjects();

        //
        if (Input.GetKeyDown(pauseKey))
        {
            SwitchPause();
            isPauseMove = false;
        }
    }

    public void SwitchPause()
    {
        if (!IsGame()) return;
        if (isPauseMove) return;

        if (pauseObject == null)
        {
            Debug.LogError("pauseObject��null�ł�");
            return;
        }

        if (state == GameState.Pause)
        {
            state = GameState.Game;
            pauseObject.SetActive(false);
            SceneUpdateManager.Instance.StartUpdate();
        }
        else if (state == GameState.Game)
        {
            state = GameState.Pause;
            pauseObject.SetActive(true);
            SceneUpdateManager.Instance.StopUpdate();
        }

        isPauseMove = true;
    }

    public void PlayerDethGameOver()
    {
        if (!IsGame()) return;
        if (state == GameState.GameOver) return;

        if (dethGameoverObject == null)
        {
            Debug.LogError("dethGameoverObject��null�ł�");
            return;
        }

        dethGameoverObject.SetActive(true);
        SceneUpdateManager.Instance.StopUpdate();
        state = GameState.GameOver;
    }

    public void ExplotionGameOver()
    {
        if (!IsGame()) return;
        if (state == GameState.GameOver) return;

        if (expGameoverObject == null)
        {
            Debug.LogError("expGameoverObject��null�ł�");
            return;
        }

        expGameoverObject.SetActive(true);
        SceneUpdateManager.Instance.StopUpdate();
        state = GameState.GameOver;
    }

    public void ChackNowScene()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            state = GameState.Game;
        }
        else
        {
            state = GameState.OtherGameScene;
        }
    }

    public bool IsGame()
    {
        return SceneManager.GetActiveScene().name == "GameScene";
    }

    private void SettingObjects()
    {
        if (!IsGame()) return;

        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        if (pauseObject == null)
        {
            pauseObject = GameObject.Find("Pause");
            pauseObject.SetActive(false);
            pauseObject.transform.position = new Vector3(0, 0, 0);
            SceneUpdateManager.Instance.StartUpdate();
        }

        if (expGameoverObject == null)
        {
            expGameoverObject = GameObject.Find("ExpGameOver");
            expGameoverObject.SetActive(false);
            expGameoverObject.transform.position = new Vector3(0, 0, 0);
        }

        if (dethGameoverObject == null)
        {
            dethGameoverObject = GameObject.Find("PlayerDethGameOver");
            dethGameoverObject.SetActive(false);
            dethGameoverObject.transform.position = new Vector3(0, 0, 0);
        }
    }

}