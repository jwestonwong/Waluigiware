using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomLetter : MonoBehaviour {


	int buttonCounts = 0;
	int buttonTarget;

	char letter;
	int letterTotal;

	// Use this for initialization
	void Start () {
		newLetter ();
		buttonTarget = Random.Range (10, 20);
	}
	
	// Update is called once per frame
	void Update () {

		if (buttonCounts >= buttonTarget) {
			
		}

	}

	void newLetter (){

	}

	void nextLetter (){
		
	}
}
