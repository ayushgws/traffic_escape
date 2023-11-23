using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour   
{
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;



    void Start()
    {
        btnMenu.onClick.AddListener(Loadmenu);
        btnRestart.onClick.AddListener(Restart); 
    }


    public void Loadmenu()
    {
        SceneLoader.Instance().OpenHomeScene();
    }

    public void Restart()
    {
        SceneLoader.Instance().RestartCurrentLevel();
    }
}
