using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerController player;

    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    private bool isPauseMove = false;//ぱーずアニメーション中か
    [SerializeField] private GameObject pauseObject = null;
    [SerializeField] private GameObject stageClearObject = null;
    [SerializeField] private GameObject expGameoverObject = null;
    [SerializeField] private GameObject dethGameoverObject = null;
    [SerializeField] private GameObject gameClearObject = null;

    //ゲームの状態
    enum GameState
    {
        Game,

        Pause,
        PauseMove,
        StageClear,
        GameOver,
        GameClear,
    }
    [SerializeField] private GameState state = GameState.Game;

    [SerializeField] private List<GameObject> stageObjects = new List<GameObject>();
    private GameObject nowStageObject = null;
    [SerializeField] private int nowStage = 0;

    public PlayerController GetPlayerController() { return player; }

    public bool LastStage() { return (nowStage == stagePrehub.Count - 1); }

    public void Start()
    {
        for (int i = 0; i < stageObjects.Count; i++)
        {
            stageObjects[i].SetActive(false);
        }

        CreateStage(nowStage);
        SettingObjects();
        StageStart();
    }

    public void Update()
    {

        //一時停止インタラクト
        if (Input.GetKeyDown(pauseKey))
        {
            SwitchPause();
            isPauseMove = false;
        }

        if (state != GameState.Game) return;

        if (player != null)
        {
            if (player.Deth)
            {
                PlayerDethGameOver();
            }
        }

    }

    public void NextStage()
    {
        nowStageObject.SetActive(false);
        nowStage++;
        CreateStage(nowStage);
        StageStart();
    }

    public void RetryStage()
    {
        nowStageObject.SetActive(false);
        CreateStage(nowStage);
        StageStart();
    }

    public void CreateStage(int stageNum)
    {
        if (stageNum < 0 || stageNum >= stageObjects.Count)
        {
            Debug.LogError("stageNumが範囲外です");
            return;
        }

        Destroy(nowStageObject);
        nowStageObject = null;

        for (int i = 0; i < stageObjects.Count; i++)
        {
            if (i == stageNum)
            {
                //生成
                nowStageObject = Instantiate(stageObjects[i]);
                nowStageObject.SetActive(true);
                break;
            }
        }
    }

    public void SwitchPause()
    {
        if (isPauseMove) return;

        if (pauseObject == null)
        {
            Debug.LogError("pauseObjectがnullです");
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
            Debug.LogError("dethGameoverObjectがnullです");
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
            Debug.LogError("expGameoverObjectがnullです");
            return;
        }

        expGameoverObject.SetActive(true);
        SceneUpdateManager.Instance.StopUpdate();
        state = GameState.GameOver;
    }

    public void StageClear()
    {
        if (state == GameState.StageClear) return;

        if (stageClearObject == null)
        {
            Debug.LogError("stageClearObjectがnullです");
            return;
        }

        stageClearObject.SetActive(true);
        SceneUpdateManager.Instance.StopUpdate();
        state = GameState.StageClear;
    }

    public void GameClear()
    {
        if (state == GameState.GameClear) return;

        if (gameClearObject == null)
        {
            Debug.LogError("gameClearObjectがnullです");
            return;
        }

        gameClearObject.SetActive(true);
        SceneUpdateManager.Instance.StopUpdate();
        state = GameState.GameClear;
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

        if (stageClearObject == null)
        {
            stageClearObject = GameObject.Find("StageClear");
            stageClearObject.SetActive(false);
            stageClearObject.transform.position = new Vector3(0, 0, 0);
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

        if (gameClearObject == null)
        {
            gameClearObject = GameObject.Find("GameClear");
            gameClearObject.SetActive(false);
            gameClearObject.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void StageStart()
    {
        state = GameState.Game;
        SceneUpdateManager.Instance.StartUpdate();

        if (pauseObject != null)
        {
            pauseObject.SetActive(false);
        }

        if (stageClearObject != null)
        {
            stageClearObject.SetActive(false);
        }

        if (expGameoverObject != null)
        {
            expGameoverObject.SetActive(false);
        }

        if (dethGameoverObject != null)
        {
            dethGameoverObject.SetActive(false);
            Debug.LogWarning("dethGameoverObjectを非表示");
        }

        if (gameClearObject != null)
        {
            gameClearObject.SetActive(false);
        }

        if (player != null)
        {
            player.ResetPlayer();
        }

    }

}
