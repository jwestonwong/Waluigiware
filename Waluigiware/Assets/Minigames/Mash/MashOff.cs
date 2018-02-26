using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashOff : MonoBehaviour {

	public float mash;
	public float ropeLocation;

	private float keywin = -5;
	private float mouseWin = 5;

	private bool victory = false;
	private bool mV = false;

	private Camera cam;

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;

	// Use this for initialization
	void Start () {
		cam = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			mash--;
		}
		if (Input.GetMouseButtonDown (0)) {
			mash++;
		}

		if (victory == false) {
			if (mash < 0) {
				ropeLocation = ((mash / -30) * keywin);
				transform.position = new Vector2 (ropeLocation, 0);
			}
				
			if (mash > 0) {
				ropeLocation = ((mash / 30) * mouseWin);
				transform.position = new Vector2 (ropeLocation, 0);
			}

			if (mash == 0) {
				this.transform.position = new Vector2 (0, 0);
			}

			if (mash >= 30) {
				victory = true;
				mV = true;
				won = true;
				winTime = Time.time;
				cam.backgroundColor = new Color32 (239, 138, 98, 255);
			} else if (mash <= -30) {
				victory = true;
				won = true;
				winTime = Time.time;
				cam.backgroundColor = new Color32 (103, 169, 207, 255);
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

	void LevelChange (){
		gM = FindObjectOfType<GameManager> ();
		if (mV) {
			gM.mouseScore++;
		} else {
			gM.keyboardScore++;
		}
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
