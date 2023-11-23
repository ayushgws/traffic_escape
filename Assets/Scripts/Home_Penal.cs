using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Home_Penal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button playBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button quitBtn;
    void Start()
    {
        playBtn.onClick.AddListener(OpenLevelSelection);
        settingBtn.onClick.AddListener(OpenSetting);
        quitBtn.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenLevelSelection()
    {
        MenuController.Instance().OpenLevel();
    }
    public void OpenSetting()
    {
        MenuController.Instance().OpenSettings();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
