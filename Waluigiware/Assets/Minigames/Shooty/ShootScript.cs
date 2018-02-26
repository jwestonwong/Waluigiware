using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour {

	public bool started = false;

	public bool mouseWon;
	public bool keyWon;
	bool noWinner = true;

	public Text display;

	float randomTimer;
	float startTimer;
	float Timer;

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	// Use this for initialization
	void Start () {
		startTimer = Time.time;
		randomTimer = Random.Range (2f, 4f);
	}
	
	// Update is called once per frame
	void Update () {

		Timer = Time.time - startTimer;

		if (started != true) {
			display.text = "Wait";
		} else {
			display.text = "Fire!";
		}

		if (randomTimer < Timer) {
			started = true;
		}

		if (started) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (noWinner) {
					keyWon = true;
					noWinner = false;
					winTime = Time.time;
					won = true;
					Debug.Log ("Keyboard Won");
				}
			}
			if (Input.GetMouseButtonDown (0)) {
				if (noWinner) {
					won = true;
					winTime = Time.time;
					mouseWon = true;
					noWinner = false;
					Debug.Log ("Mouse Won");
				}
			}
		}

		endWin = Time.time - winTime;
		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
				won = false;
			}
		}

	}

	void LevelChange(){
		gM = FindObjectOfType<GameManager> ();
		if (mouseWon) {
			gM.mouseScore++;
		} else {
			gM.keyboardScore++;
		}
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
