using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform Target;

    public Vector2 Offset = new Vector2(0, -3);
    public Vector2 LerpAmount = new Vector2(0.3f, 0.1f);

    public float MinY = -0.28f;

	// Use this for initialization
	void Start () {
        Target = GameObject.Find("Dino").transform;

        if (Target != null) {
            Vector3 pos = this.transform.position;
            pos.x = Target.position.x + Offset.x;
            pos.y = Target.position.y + Offset.y;
            this.transform.position = pos;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Target == null)
            return;
        
        Vector3 pos = this.transform.position;
        pos.x = Mathf.Lerp(pos.x, Target.position.x + Offset.x, LerpAmount.x);
        pos.y = Mathf.Lerp(pos.y, Target.position.y + Offset.y, LerpAmount.y);

        pos.y = pos.y <= MinY ? MinY : pos.y;

        this.transform.position = pos;
	}
}
