using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private Button LevelBtn;
    // Start is called before the first frame update
    void Start()
    {
        LevelBtn = GetComponent<Button>();
        LevelBtn.onClick.AddListener(LevelOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelOpen()
    {
       SceneLoader.Instance().OpenLevel("Level1");
    }
}
