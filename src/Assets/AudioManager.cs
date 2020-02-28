using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    public AudioClip bgMainMenuClip;
    public AudioClip bgGameClip;

    private AudioSource audioSrc;
    private String currentLevel;

    private void Awake()
    {
        CreateSingleton();
        audioSrc = this.gameObject.GetComponent<AudioSource>();
    }

    private void CreateSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBGMusic();
    }

    // Update is called once per frame
    void Update()
    {
        PlayBGMusic();
    }

    private void PlayBGMusic()
    {
        if (currentLevel != SceneManager.GetActiveScene().name)
        {
            currentLevel = SceneManager.GetActiveScene().name;
            audioSrc.Stop();
            audioSrc.clip = GetCurrentBGClip();
            audioSrc.Play();
        }
    }

    private AudioClip GetCurrentBGClip()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "MainMenu")
        {
            return bgMainMenuClip;
        } else
        {
            return bgGameClip;
        }
    }
}
