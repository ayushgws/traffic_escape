using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameWiningPanel : MonoBehaviour
{
    // Start is called before the first frame updat
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnNextLevel;
    [SerializeField]TextMeshProUGUI textScoreCount;
    [SerializeField] TextMeshProUGUI textScoreCount2;

    void Start()
    {
        AudioManager.Instance().StopMusic();
        btnRestart.onClick.AddListener(Restart);
        btnMenu.onClick.AddListener(MainMenu);
        btnNextLevel.onClick.AddListener(NextLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        SceneLoader .Instance().RestartCurrentLevel();
    }
    public void NextLevel()
    {
        SceneLoader.Instance().NextLevel();
    }
    public void MainMenu()
    {
        SceneLoader.Instance().OpenHomeScene();
    }
    public void UpdateScoreCount(int Score)
    {
        textScoreCount.text = Score.ToString();
        textScoreCount2 .text = Score.ToString();
    }
}
