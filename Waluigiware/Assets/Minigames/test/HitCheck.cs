using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour {

	private MouseTracking mouseTrack;

	// Use this for initialization
	void Start () {
		mouseTrack = gameObject.GetComponent<MouseTracking> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			if (mouseTrack != null) {
				Destroy (mouseTrack);
				mouseTrack = gameObject.GetComponent<MouseTracking> ();
			}
		}
	}
}
