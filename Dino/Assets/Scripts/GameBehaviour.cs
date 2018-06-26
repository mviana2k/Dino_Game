using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour {

    public int Apples = 0;
    public int Oranges = 0;
    public bool IsGameRunning = true;

    public DIno Dino;
    public float restartClock = 0;

	void Start() {
        GameObject startPoint = GameObject.Find("StartPoint");
        if(startPoint == null) {
            throw new UnityException("Start point do not exists!");
        }

        GameObject dino = GameObject.Find("Dino");
        if (dino == null) {
            throw new UnityException("Dino do not exists!");
        }
        this.Dino = dino.GetComponent<DIno>();

        if (GameObject.Find("ExitPoint") == null)
            throw new UnityException("Exit point do not exists!");

        dino.transform.position = new Vector3 (startPoint.transform.position.x, startPoint.transform.position.y - 1, 0);
	}

	void Update() {
        if(Dino.IsDead()) {
            restartClock += Time.deltaTime;
            if (restartClock >= 3.0f) {
                Restart();
            }
        }
	}
    
	public void  AddApple() {
        Apples += 1;
    }

    public void AddOrange() {
        Oranges += 1;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
