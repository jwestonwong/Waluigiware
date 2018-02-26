using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupHide : MonoBehaviour {

	public bool hidden = false;

	public int cupHidden;

	public Text instructions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (hidden) {
			instructions.text = "Choose the right cup.";
		}

		if (hidden == false) {
			if (Input.GetKeyDown (KeyCode.A)) {
				cupHidden = 1;
				hidden = true;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				cupHidden = 2;
				hidden = true;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				cupHidden = 3;
				hidden = true;
			}
		}



	}
}
