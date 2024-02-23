using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerController player;

    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    private bool isPauseMove = false;//�ρ[���A�j���[�V��������
    [SerializeField] private GameObject pauseObject = null;
    [SerializeField] private GameObject expGameoverObject = null;
    [SerializeField] private GameObject dethGameoverObject = null;

    //�Q�[���̏��
    enum GameState
    {
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

        //�ꎞ��~�C���^���N�g
        if (Input.GetKeyDown(pauseKey))
        {
            SwitchPause();
            isPauseMove = false;
        }

        if (state != GameState.Game) return;

        if (player != null)
        {
            if(player.Deth)
            {
                PlayerDethGameOver();
            }
        }

    }

    public void SwitchPause()
    {
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

    private void SettingObjects()
    {
        if (player == null)
        {
            GameObject.Find("Player").TryGetComponent<PlayerController>(out player);
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
