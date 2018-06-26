using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DinoColliderHelper : MonoBehaviour {

    public bool IsColliding = false;

    public Action<Collider2D> OnTriggerEnterAction; 

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Platform") == true) {
            IsColliding = true;
        }

        if (OnTriggerEnterAction != null)
            OnTriggerEnterAction(coll);

    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag("Platform") == true) {
            IsColliding = false;

        }

    }
}