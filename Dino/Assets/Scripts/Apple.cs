using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    SpriteRenderer renderer;
    AudioSource appleAudio;
    bool readyToRemove = false;

	void Start() {
        renderer = GetComponent<SpriteRenderer> ();
        appleAudio = GetComponent<AudioSource> ();
	}

	private void Update() {
        if(readyToRemove == true && appleAudio.isPlaying == false) {
            Destroy (this.gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Dino") == true && readyToRemove == false) {
            appleAudio.Play();
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddApple();
            readyToRemove = true;
            renderer.enabled = false;
        }
	}
}
