using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_AudioSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private AudioSource _audioSource;
    [SerializeField] private AudioClip collisionClip;
    [SerializeField] private AudioClip moveClip;
    [SerializeField] private AudioClip returnClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CollisionSound()
    {
        _audioSource.clip = collisionClip;
        _audioSource.Play();
    }
    public void MoveSound()
    {
        _audioSource.clip = moveClip;
        _audioSource.Play();
    }
    public void ReturnSound()
    {
        _audioSource.clip = returnClip;
        _audioSource.Play();
    }
}
