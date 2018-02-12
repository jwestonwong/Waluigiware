using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulerController : MonoBehaviour {

	catchZone cZ;

	// Use this for initialization
	void Start () {
		cZ = FindObjectOfType<catchZone> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cZ.caught == true) {
			Destroy (gameObject.GetComponent<Rigidbody2D> ());
		}
	}
}
