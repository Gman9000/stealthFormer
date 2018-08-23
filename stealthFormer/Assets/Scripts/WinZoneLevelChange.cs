using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneLevelChange : MonoBehaviour {
    public string nextLevel;
    private LevelManager theLevelManager;
	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            theLevelManager.NextLevel(nextLevel);
        }
    }
}
