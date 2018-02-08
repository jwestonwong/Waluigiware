using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDeletion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Obstacle") {
			Destroy (other.gameObject);
		}
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			//Call Level End (w/ Ball player lose)
		}
	}
}
