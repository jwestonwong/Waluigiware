using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCon : MonoBehaviour {

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	private AudioSource aS;
	private Camera cam;

	// Use this for initialization
	void Start () {
		aS = GetComponent<AudioSource> ();
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

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Keyboard") {
			Debug.Log ("Ruler Won");
			aS.Play ();
			cam.backgroundColor = new Color32 (103, 169, 207, 255);
			winTime = Time.time;
			won = true;
		}
	}

	void LevelChange (){
		gM = FindObjectOfType<GameManager> ();
		gM.keyboardScore++;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
