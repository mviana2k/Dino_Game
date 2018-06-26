using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour {

    SpriteRenderer renderer;
    AudioSource orangeAudio;
    bool readyToRemove = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        orangeAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (readyToRemove == true && orangeAudio.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Dino") == true && readyToRemove == false)
        {
            orangeAudio.Play();
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddOrange();
            readyToRemove = true;
            renderer.enabled = false;
        }
    }
}
