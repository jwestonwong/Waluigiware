using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour {

	private MouseTracking mouseTrack;
	private AudioSource aS;

	// Use this for initialization
	void Start () {
		mouseTrack = GetComponent<MouseTracking> ();
		aS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			if (mouseTrack != null) {
				Destroy (mouseTrack);
				aS.Play ();
				mouseTrack = gameObject.GetComponent<MouseTracking> ();
			}
		}
	}
}
