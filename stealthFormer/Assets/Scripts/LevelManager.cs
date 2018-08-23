using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void NextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }


}
