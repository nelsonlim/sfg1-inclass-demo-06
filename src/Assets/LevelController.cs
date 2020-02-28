using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadLevel("Level01");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadLevel("Level02");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLevel("MainMenu");
        }
    }

    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
