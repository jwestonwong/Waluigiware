using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchZone : MonoBehaviour {

	bool inZone = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (inZone) {
				Debug.Log ("Ruler Catch!");
			}
		}

	}

	void OnTriggerStay2D(Collider2D other){
		inZone = true;
		Debug.Log ("In Zone");
	}

	void OnTriggerExit2D(Collider2D other){
		inZone = false;
	}
}
