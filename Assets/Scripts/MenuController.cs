using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    private static MenuController instance;
    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject settingsPanel;

    public static MenuController Instance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        OpenHome();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OpenHome()
    {
        homePanel.SetActive(true);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(false);

    }
    void OpenLevel()
    {
        homePanel.SetActive(false);
        levelPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    void OpenSettings()
    {
        homePanel.SetActive(false);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
