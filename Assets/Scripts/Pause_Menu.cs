using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnResume;
    


    void Start()
    {
        btnMenu.onClick.AddListener(Loadmenu);
        btnResume.onClick.AddListener(Resume);
        btnRestart.onClick.AddListener(Restart);
    }

   
   public void Resume()
    {
        LevelManager.Instance().Resume();
    }
    
    public void Loadmenu()
    {

    }
  
    public void Restart()
    {

    }
   
    
}
