using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDeletion : MonoBehaviour {

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	private testSpawner ts;

	// Use this for initialization
	void Start () {
		
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
			winTime = Time.time;
			won = true;
		}
	}

	void LevelChange (){
		ts = FindObjectOfType<testSpawner> ();
		ts.Refresh ();
		gM = FindObjectOfType<GameManager> ();
		gM.keyboardScore++;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
