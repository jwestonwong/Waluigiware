using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTimer : MonoBehaviour {

	float startTimer;
	float elapsedTimer;
	public float endTimer;

	bool beat = false;
	bool unwon = true;

	private GameManager gm;

	// Use this for initialization
	void Start () {
		startTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTimer = Time.time - startTimer;
		if (elapsedTimer >= endTimer) {
			if (beat) {
				gm.LevelChange ();
				beat = false;
			} else if (unwon){
				Debug.Log ("Mouse Won");
				gm = FindObjectOfType<GameManager> ();
				gm.mouseScore++;
				startTimer = Time.time;
				endTimer = 2f;
				beat = true;
				unwon = false;
			}
		}
	}
}
