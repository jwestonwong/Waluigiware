using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDisplay : MonoBehaviour {

	private GameManager gm;

	public Text tx;

	// Use this for initialization
	void Start () {
		gm = FindObjectOfType<GameManager> ();
		if (gm.mouseWon) {
			tx.text = ("Mouse Won!");
		} else if (gm.keyboardWon) {
			tx.text = ("Keyboard Won!");
		} else {
			tx.text = ("Tie!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
