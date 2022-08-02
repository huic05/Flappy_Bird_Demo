using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassGameScipt : MonoBehaviour
{
    private GameObject ClickToPlayText;
    private ClassBird bird;
    private GameObject losemenu;

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
    }
    public void FromPlayToLoes()
    {
        _currentgame = GameState.LostMenu;
    }
    public void FromPlayToLose(int counter)
    {
        ClickToPlayText.SetActive(false);
        losemenu.SetActive(true);
    }
   
}
