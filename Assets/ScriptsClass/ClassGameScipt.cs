using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ClassGameScipt : MonoBehaviour
{
    private GameObject ClickToPlayText;
    private ClassBird bird;
    private GameObject losemenu;
    private ClassPipeSpawner pipeSpawner;
    public Sprite silver;
    public Sprite gold;
    private Image medal;
    private TextMeshProUGUI score;
    private static Data _instance;
    public int scorecounter = 0;
    private Data data;
    private TextMeshProUGUI best;
    

    public enum GameState
    {
        WaitingToClick,
        Playing,
        LostMenu,
    }
    public GameState _currentgame = GameState.WaitingToClick;
    // Start is called before the first frame update
    void Start()
    {
        ClickToPlayText = GameObject.Find("Canvas").transform.Find("ClickToPlay").gameObject;
        ClickToPlayText.SetActive(true);
        bird = GameObject.Find("Flappy Bird").GetComponent<ClassBird>();
        losemenu = GameObject.Find("Canvas").transform.Find("Lost Menu").gameObject;
        losemenu.SetActive(false);
        pipeSpawner = GameObject.Find("PipeSpawner").GetComponent<ClassPipeSpawner>();
        medal = GameObject.Find("Canvas").transform.Find("Lost Menu").transform.Find("Medal").GetComponent<Image>();
        // score = GameObject.Find("Canvas").transform.Find("Lost menu").transform.Find("Score").GetComponent<TextMeshProUGUI>();
        data = GameObject.Find("Data").GetComponent<Data>();
        // best = GameObject.Find("Canvas").transform.Find("Lost menu").transform.Find("Best").GetComponent<TextMeshProUGUI>();
     

    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentgame)
        {
            case GameState.WaitingToClick:
                WaitingToClick();
                break;
            case GameState.Playing:
                UpdatePlaying();
                break;
            case GameState.LostMenu:
                break;
        }
    }
    private void WaitingToClick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FromClickToPlay();
        }
    }
    private void FromClickToPlay()
    {
        bird.SetUpBird();
        ClickToPlayText.SetActive(false);
        _currentgame = GameState.Playing;

      

    }
    private void UpdatePlaying()
    {
        bird.UpdateBird();
        pipeSpawner.UpdatePipeSpawner();
    }
    public void FromPlayToLoes()
    {
        _currentgame = GameState.LostMenu;
    }
    public void FromPlayToLose(int counter)
    {
        ClickToPlayText.SetActive(false);
        losemenu.SetActive(true);
        if (data.GetScore() < counter)
        {
            data.SetScore(counter);
        }
        best.SetText(data.GetScore().ToString());
        if (counter >= 10 && counter < 20)
        {
            medal.sprite = silver;

        }
        else if (counter >= 20)
        {
            medal.sprite = gold;
        }
        score.SetText(counter.ToString());
    }
    public void Replay()
    {
        SceneManager.LoadScene("GameSceneClass");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MenuSceneClass");
    }
    public void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // _instance = this; // error
        DontDestroyOnLoad(gameObject);

    }
    public void SetScore(int s)
    {
        scorecounter = s;
    }
    public int GetScore()
    {
        return scorecounter;
    }


}
