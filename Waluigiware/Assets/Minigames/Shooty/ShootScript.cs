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

	private AudioSource aS;
	private Camera cam;

	// Use this for initialization
	void Start () {
		startTimer = Time.time;
		randomTimer = Random.Range (2f, 4f);
		cam = FindObjectOfType<Camera> ();
		aS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		Timer = Time.time - startTimer;

		if (started != true) {
			display.text = "Wait";
		} else {
			display.text = "Click/Space!";
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
					aS.Play ();
					cam.backgroundColor = new Color32 (103, 169, 207, 255);
				}
			}
			if (Input.GetMouseButtonDown (0)) {
				if (noWinner) {
					won = true;
					winTime = Time.time;
					mouseWon = true;
					noWinner = false;
					Debug.Log ("Mouse Won");
					aS.Play ();
					cam.backgroundColor = new Color32 (239, 138, 98, 255);
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
