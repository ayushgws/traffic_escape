using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMoveCount;
    [SerializeField] private Button btnPause;

    public void Start()
    {
        btnPause.onClick.AddListener(PauseGame);

    }  

    public void PauseGame()
    {
        LevelManager.Instance().Pause();
    }
    public void UpdateMoveCount(int move)
    {
        textMoveCount.text = move.ToString();   
    }
    
}
