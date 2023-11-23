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
    public void ResetScreen()
    {
        homePanel.SetActive(false);
        levelPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void OpenHome()
    {
        ResetScreen();
        homePanel.SetActive(true);
    }
    public void OpenLevel()
    {
        ResetScreen();
        levelPanel.SetActive(true);
    }
    public void OpenSettings()
    {
        ResetScreen();
        settingsPanel.SetActive(true);
    }
}
