using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button backBtn;
    
    void Start()
    {
        backBtn.onClick.AddListener(BackButton);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BackButton()
    {
        MenuController.Instance().OpenHome();
    }
    void LevelSelect()
    {

    }
}
