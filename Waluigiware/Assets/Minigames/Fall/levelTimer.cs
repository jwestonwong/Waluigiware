﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTimer : MonoBehaviour {

	float startTimer;
	float elapsedTimer;
	public float endTimer;

	bool beat = false;
	bool unwon = true;

	private GameManager gm;
	private testSpawner tS;
	private Camera cam;
	private AudioSource aS;

	public keyBowlController kB;
	public mouseBowlController mB;

	// Use this for initialization
	void Start () {
		startTimer = Time.time;
		aS = GetComponent<AudioSource> ();
		cam = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTimer = Time.time - startTimer;
		if (elapsedTimer >= endTimer) {
			if (beat) {
				gm.LevelChange ();
				beat = false;
			} else if (unwon){
				if (kB.keyScore > mB.mousescore) {
					gm = FindObjectOfType<GameManager> ();
					cam.backgroundColor = new Color32 (103, 169, 207, 255);
					if (aS != null) {
						aS.Play ();
					}
					gm.keyboardScore++;
					startTimer = Time.time;
					endTimer = 2f;
					beat = true;
					unwon = false;
				} else if (kB.keyScore == mB.mousescore) {
					endTimer += 0.5f;
				} else {
					gm = FindObjectOfType<GameManager> ();
					cam.backgroundColor = new Color32 (239, 138, 98, 255);
					if (aS != null) {
						aS.Play ();
					}
					gm.mouseScore++;
					startTimer = Time.time;
					endTimer = 2f;
					beat = true;
					unwon = false;
				}
			}
		}
	}
}
