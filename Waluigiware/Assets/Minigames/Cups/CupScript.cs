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

	public AudioClip win;
	public AudioClip lose;
	public AudioSource auPlayer;

	private Camera cam;

	// Use this for initialization
	void Start () {
		cH = FindObjectOfType<CupHide> ();
		auPlayer = GetComponent<AudioSource> ();
		cam = FindObjectOfType<Camera> ();
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
						auPlayer.clip = win;
						cam.backgroundColor = new Color32 (239, 138, 98, 255);
						auPlayer.Play ();
						winTime = Time.time;
					} else {
						Debug.Log ("Incorrect");
						gameOver = true;
						won = true;
						mW = false;
						cam.backgroundColor = new Color32 (103, 169, 207, 255);
						auPlayer.clip = lose;
						auPlayer.Play ();
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
