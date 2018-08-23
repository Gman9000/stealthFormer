using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public PlayerController thePlayer; //refernce to the playerControler object
    private bool isRespawning; // is player respawning?

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        isRespawning = false; // set it to true so that player won't respawn during wiating time

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo"); // how to call a Co-Routine Function
    }
    // respawn Co-Routine( Kind of like a Thread )
    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false); // deactivate player when dead


        // how to pause the script for a few seconds
        yield return new WaitForSeconds(waitToRespawn);

        isRespawning = false; // set it to false so that player can respawn


        thePlayer.transform.position = thePlayer.respawnPosition; // set respawn position
        thePlayer.gameObject.SetActive(true); // make character active when respwan actually happens
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
