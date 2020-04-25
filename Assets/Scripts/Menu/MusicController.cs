﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public static MusicController instance;
    // Start is called before the first frame update
    private void Awake() {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {

    }
    void MakeSingleton(){
        if (instance!= null)
        {
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayMusic(bool play){
        if (play)
        {
            if (!audioSource.isPlaying)
            {   
                audioSource.Play();
            }
        }else{
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
