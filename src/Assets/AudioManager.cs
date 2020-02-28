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
        currentLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        PlayNextLevelBGMusic();
    }

    private void PlayNextLevelBGMusic()
    {
        if (currentLevel != SceneManager.GetActiveScene().name)
        {
            currentLevel = SceneManager.GetActiveScene().name;
            audioSrc.Stop();
            audioSrc.clip = GetCurrentBGClip();
            audioSrc.Play();
        }
    }

    private void PlayBGMusic()
    {
        audioSrc.clip = GetCurrentBGClip();
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
        audioSrc.Play();
    }

    private AudioClip GetCurrentBGClip()
    {
        String activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "MainMenu")
        {
            return bgMainMenuClip;
        } else
        {
            return bgGameClip;
        }
    }
}
