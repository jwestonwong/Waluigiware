using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerDropper : MonoBehaviour {

	public GameObject ruler;
	bool dropped = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (dropped == false) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Instantiate (ruler, transform.position, Quaternion.identity);
				dropped = true;
			}
		}
	}
}
