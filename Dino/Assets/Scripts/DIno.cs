using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIno : MonoBehaviour {

    GameBehaviour game;

    DinoColliderHelper bottomHelper;
    DinoColliderHelper rightHelper;
    DinoColliderHelper leftHelper;

    AudioSource jumpAudio;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer renderer;

    bool isJumping = false;
    bool isDead = false;
    bool IsAlive = false;

    public float Velocity = 1f;
    public float JumpForce = 10f;

	// Use this for initialization
	void Start () {
        game = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();

        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
        renderer = GetComponent<SpriteRenderer>();

        bottomHelper = GetComponentsInChildren<DinoColliderHelper> () [0];
        bottomHelper.OnTriggerEnterAction = delegate(Collider2D obj) {
            if(obj.CompareTag("WeakPoint")) {
                obj.GetComponentInParent<Trex>().Kill();
                Jump();
            }
        };
        rightHelper = GetComponentsInChildren<DinoColliderHelper> () [1];
        leftHelper = GetComponentsInChildren<DinoColliderHelper>() [2];

        jumpAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (game.IsGameRunning == false) {
            animator.SetFloat("Velocity", 0);
            return;
        } else if (this.isDead == true) {
            return;
        } else if (this.transform.position.y < -5.0f) {
            this.Kill();
            return;
        }
            
        
        Vector2 dir = Vector2.zero;

        if (Input.GetKey (KeyCode.A) == true && leftHelper.IsColliding == false) {
            dir.x = -1;
        } else if (Input.GetKey (KeyCode.D) == true && rightHelper.IsColliding == false) {
            dir.x = 1;
        }

        if(Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
            Jump ();
        }

        Vector2 vel = rb.velocity;
        vel.x = dir.x * Velocity;
        rb.velocity = vel;

        animator.SetFloat("Velocity", GetAbsRunVelocity());

        if (rb.velocity.x > 0) {
            renderer.flipX = false;
        } else if (rb.velocity.x < 0) {
            renderer.flipX = true;
        }

        isJumping = !bottomHelper.IsColliding;
        animator.SetBool("Jump", isJumping);
       
	}

    private void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, JumpForce));
        jumpAudio.Play();
    }

    public float GetAbsRunVelocity() {
        return Mathf.Abs(rb.velocity.x);

    }

    public bool IsJumping() {
        return isJumping;

    }

    public bool IsDead() {
        return isDead;
    }

    public void Kill() {
        if (this.isDead == false) {  
        this.isDead = true;
        animator.SetBool ("Dead", this.isDead); 
        
        }
    }

	

}
