using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    private bool isPause;
    [SerializeField] private int moveCount;
    private int spaceShipCount;
    private int scrCount;
    public static LevelManager Instance()
    { return instance; }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameplayUIManager.Instance().UpdateMoveCount(moveCount);


    }
    public void Pause()
    {
        if (!isPause)
        {
            isPause = true;
            GameplayUIManager.Instance().OpenPause();
            Time.timeScale = .0f;
        }
    }

    public void Resume()
    {
        if (isPause)
        {
            isPause = false;
            GameplayUIManager.Instance().OpenGamePlay();
            Time.timeScale = 1f;
        }
    }
    public void Move()
    {

        moveCount--;
        GameplayUIManager.Instance().UpdateMoveCount(moveCount);

    }

    public void CheckMove()
    {
        if (moveCount == 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        GameplayUIManager.Instance().gameOver();
    }
    public void CheckSpaceShipCount()
    {
        spaceShipCount--;
        if (spaceShipCount == 0)
        {
            GameplayUIManager.Instance().GameWiningScreen();
        }
    }
    public void AddSpaceShip()
    {

        spaceShipCount++;
    }
    public void ScoreCount()
    {
        scrCount += 5;
        GameplayUIManager.Instance().UpdateScoreCount(scrCount);

    }
}
