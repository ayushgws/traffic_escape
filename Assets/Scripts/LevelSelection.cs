using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelection : MonoBehaviour
{

    

    [SerializeField] private int levelCount;
    [SerializeField] private string levelNamePrefix;

    [SerializeField] private GameObject levelContainer;
    [SerializeField] private GameObject levelButtonPrefab;

    private List<GameObject> levelList = new List<GameObject>();

    private int unlockedLevel;

    private void Start()
    {

        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);


      

        for (int i = 1; i <= levelCount; i++)
        {

            GameObject levelObj = Instantiate(levelButtonPrefab, levelContainer.transform);
            levelObj.GetComponent<LevelButton>().SetLevelName(levelNamePrefix + i);
            levelObj.GetComponent<LevelButton>().SetLevelCount(i);

            if (i <= unlockedLevel)
            {
                levelObj.GetComponent<LevelButton>().HighlightImage();
            }
            else
            {
                levelObj.GetComponent<Button>().enabled = false;
                levelObj.GetComponent<LevelButton>().SetLockedImage();
            }
            levelList.Add(levelObj);
        }
    }

   

}
