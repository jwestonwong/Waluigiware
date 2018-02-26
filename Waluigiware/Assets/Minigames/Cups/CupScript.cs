using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour {

	public int cupInt;

	public CupHide cH;

	public static bool gameOver = false;

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	private bool mW = false;

	// Use this for initialization
	void Start () {
		cH = FindObjectOfType<CupHide> ();
	}
	
	// Update is called once per frame
	void Update () {
		endWin = Time.time - winTime;
		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
				won = false;
			}
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		//Debug.Log("Mouse is over GameObject.");
		if (cH.hidden) {
			if (Input.GetMouseButtonDown (0)) {
				if (gameOver == false) {
					if (cupInt == cH.cupHidden) {
						Debug.Log ("Correct");
						gameOver = true;
						won = true;
						mW = true;
						winTime = Time.time;
					} else {
						Debug.Log ("Incorrect");
						gameOver = true;
						won = true;
						mW = false;
						winTime = Time.time;
					}
				}
			}
		}
	}

	void LevelChange(){
		gM = FindObjectOfType<GameManager> ();
		if (mW) {
			gM.mouseScore++;
		} else {
			gM.keyboardScore++;
		}
		gameOver = false;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
