using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDeletion : MonoBehaviour {

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	private testSpawner ts;

	private Camera cam;

	// Use this for initialization
	void Start () {
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
		if (other.tag == "Obstacle") {
			Destroy (other.gameObject);
		}
		if (other.tag == "Mouse") {
			Destroy (other.gameObject);
			cam.backgroundColor = new Color32 (103, 169, 207, 255);
			winTime = Time.time;
			won = true;
		}
	}

	void LevelChange (){
		ts = FindObjectOfType<testSpawner> ();
		gM = FindObjectOfType<GameManager> ();
		gM.keyboardScore++;
		ts.Refresh ();
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
