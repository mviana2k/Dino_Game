using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trex : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;

    public int Direction = -1;
    public float Velocity = 10F;
    public bool IsAlive = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
	}

	void Update() {
        if (IsAlive == false) {
            if (transform.position.y < -15f) {
                Destroy(this.gameObject);
            }    
        }
	}

	// Update is called once per frame
	void FixedUpdate () {
        if (IsAlive) {
            rb.velocity = new Vector2(Velocity * Direction, rb.velocity.y);
        }

        animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
	}

    public void Kill() {
        if (IsAlive) {
            IsAlive = false;
            GetComponent<CapsuleCollider2D> ().enabled = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, 5));
        }
    }

	void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag ("Platform") && IsAlive) {
            rb.velocity = new Vector2(0, rb.velocity.y);
            Direction = -Direction;
            this.transform.localScale = new Vector3 (
                this.transform.localScale.x * -1, 
                this.transform.localScale.y, 
                this.transform.localScale.z);
        }
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag ("Dino")) {
            other.gameObject.GetComponent<DIno> ().Kill ();
            this.Velocity = 0;

        }
	}
}
