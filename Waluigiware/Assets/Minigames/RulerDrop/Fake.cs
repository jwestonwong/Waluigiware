using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake : MonoBehaviour {

	public float wiggleRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Wiggle ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Wiggle ();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			Wiggle ();
		}
	}

	void Wiggle (){
		wiggleRange = (Random.Range (-0.1f, 0.1f)) + transform.position.y;
		transform.position = new Vector2 (transform.position.x, wiggleRange);
	}
}
