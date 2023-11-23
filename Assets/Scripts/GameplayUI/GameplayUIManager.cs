using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    
    private static GameplayUIManager instance;
    
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject pausePenel;
    [SerializeField] private GameObject gameOverPenal;
    [SerializeField] private GameObject WiningPenal;
    public static GameplayUIManager Instance() {  return instance; }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return; 
        }
        instance = this;
    }
    private void Start()
    {
        OpenGamePlay();
    }

    private void ResetAllScreen()
    {
        gameplayPanel.SetActive(false);
        pausePenel.SetActive(false);
        WiningPenal.SetActive(false);
        gameOverPenal.SetActive(false);
    }

    public void OpenPause() 
    {
        ResetAllScreen();
        pausePenel.SetActive(true);
    }

    public void OpenGamePlay()
    {
        ResetAllScreen();
        gameplayPanel.SetActive(true);
    }
    public void UpdateMoveCount(int move)
    {
        gameplayPanel.GetComponent<GameplayPanel>().UpdateMoveCount(move);
    }
    public void gameOver()
    {
        ResetAllScreen();
       gameOverPenal.SetActive(true);

    }
    public void GameWiningScreen()
    {
        ResetAllScreen();
        WiningPenal.SetActive(true);
    }
    public void UpdateScoreCount(int scrcount) 
    {
        WiningPenal.GetComponent<GameWiningPanel>().UpdateScoreCount(scrcount);
    }

}
