using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomLetter : MonoBehaviour {

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	int buttonCounts = 0;
	int buttonTarget;

	public Text text;

	public char [] letters;
	public char letterCurrent;
	int letterTotal;

	// Use this for initialization
	void Start () {
		newLetter ();
		buttonTarget = Random.Range (10, 20);
	}
	
	// Update is called once per frame
	void Update () {
		endWin = Time.time - winTime;

		if (letterCurrent == letters [0]) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				buttonCounts++;
				Debug.Log ("Q Pressed");
			}
		} else if (letterCurrent == letters [1]) {
			if (Input.GetKeyDown (KeyCode.W)) {
				buttonCounts++;
				Debug.Log ("W Pressed");
			}
		} else if (letterCurrent == letters [2]) {
			if (Input.GetKeyDown (KeyCode.E)) {
				buttonCounts++;
				Debug.Log ("E Pressed");
			}
		} else if (letterCurrent == letters [3]) {
			if (Input.GetKeyDown (KeyCode.R)) {
				buttonCounts++;
				Debug.Log ("R Pressed");
			}
		} else if (letterCurrent == letters [4]) {
			if (Input.GetKeyDown (KeyCode.A)) {
				buttonCounts++;
				Debug.Log ("A Pressed");
			}
		} else if (letterCurrent == letters [5]) {
			if (Input.GetKeyDown (KeyCode.S)) {
				buttonCounts++;
				Debug.Log ("S Pressed");
			}
		} else if (letterCurrent == letters [6]) {
			if (Input.GetKeyDown (KeyCode.D)) {
				buttonCounts++;
				Debug.Log ("D Pressed");
			}
		} else {
			if (Input.GetKeyDown (KeyCode.F)) {
				buttonCounts++;
				Debug.Log ("F Pressed");
			}
		}

		if (buttonCounts >= buttonTarget) {
			newLetter ();
			buttonCounts = 0;
			buttonTarget = Random.Range (10, 20);
			letterTotal++;
			Debug.Log ("Next Letter");
		}

		if (letterTotal >= 8) {
			won = true;
			winTime = Time.time;
		}

		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
			}
		}

	}

	void newLetter (){
		letterCurrent = letters[Random.Range(0,letters.Length)];
		if (letterTotal < 8) {
			text.text = (letterCurrent.ToString ());
		} else {
			text.text = ("Mouse Won!");
		}
	}

	void LevelChange (){
		gM = FindObjectOfType<GameManager> ();
		gM.keyboardScore++;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
