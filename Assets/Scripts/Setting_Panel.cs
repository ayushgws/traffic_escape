using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_Panel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button SoundBtn;
    [SerializeField] private Button musicBtn;
    [SerializeField] private Button backBtn;
    void Start()
    {
        SoundBtn.onClick.AddListener(ToggleSound);
        musicBtn.onClick.AddListener(ToggleMusic);
        backBtn.onClick.AddListener(PlayBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ToggleSound()
    {

    }
    void ToggleMusic()
    {

    }
    void PlayBack()
    {
        MenuController.Instance().OpenHome();
    }

}
