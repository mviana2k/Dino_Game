﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour {

    public string NextLevel = null;
    public float LoadDelay = 3f;

    private float counter = 0;
    private bool loadNextLevel = false;
	
	// Update is called once per frame
	void Update () {
        if (loadNextLevel == true) {
            counter += Time.deltaTime;
            if (counter >= LoadDelay) {
                loadNextLevel = false;
                SceneManager.LoadScene (NextLevel);
            }
        }
	}

	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag ("Dino")) {
            GameBehaviour game = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();
            if (game.IsGameRunning) {
                game.IsGameRunning = false;
                if (string.IsNullOrEmpty (NextLevel) == false) {
                    loadNextLevel = true;
                }
            }
        }
		
	}
}
