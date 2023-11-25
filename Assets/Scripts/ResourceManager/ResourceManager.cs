using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<ResourceItem> resources;

    private static ResourceManager instance;

    public static ResourceManager Instance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetLocalStore();
    }

    public void GetLocalStore()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].count = PlayerPrefs.GetInt(resources[i].PrefName, 0);
        }
    }

    public void SaveData(string name,int count)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i].name == name)
            {
                resources[i].count = count;
            }
        }
    }

}

[System.Serializable]
public class ResourceItem
{
    public string name;
    public int count;
    public string PrefName;
}
