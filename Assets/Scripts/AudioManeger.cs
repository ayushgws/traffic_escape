using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManeger : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] AudioSource backgroundSource;
    private bool b_Music;


    void Start()
    {
        backgroundSource.GetComponent<AudioSource>();
        b_Music = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (b_Music)
        {
            backgroundSource.Play();
        }
        else
        {
            backgroundSource.Stop();
        }
    }
}
