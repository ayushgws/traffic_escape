using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
   

    public static SceneLoader Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OpenHomeScene()
    {
        SceneManager.LoadScene(References.HomeScene);
    }

    public void OpenSplashScene()
    {
        SceneManager.LoadScene(References.SplashScene);
    }

   public void OpenLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartCurrentLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        string levelCount = levelName.Substring(5);
        int count = int.Parse(levelCount);
        count++;
        SceneManager.LoadScene("Level"+count);


    }

}
