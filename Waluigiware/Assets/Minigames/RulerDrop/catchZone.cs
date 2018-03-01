using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchZone : MonoBehaviour {

	bool inZone = false;
	bool clicked = false;
	public bool caught = false;
	public GameObject leftHand;
	public GameObject rightHand;

	public Vector3 leftEnd = new Vector3 (-0.8f, 0f);
	public Vector3 rightEnd = new Vector3 (0.8f, 0f);

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin = 1f;

	public AudioSource auPlayer;
	private Camera cam;

	// Use this for initialization
	void Start () {
		auPlayer = GetComponent<AudioSource> ();
		cam = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			clicked = true;
			if (inZone) {
				caught = true;
				Debug.Log ("Ruler Catch!");
				auPlayer.Play ();
				cam.backgroundColor = new Color32 (239, 138, 98, 255);
				winTime = Time.time;
				won = true;
			}
		}
		if (clicked) {
			leftHand.transform.position = Vector3.Lerp (leftHand.transform.position, leftEnd, 5f);
			rightHand.transform.position = Vector3.Lerp (rightHand.transform.position, rightEnd, 5f);
		}
		endWin = Time.time - winTime;
		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
				won = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		inZone = true;
		Debug.Log ("In Zone");
	}

	void OnTriggerExit2D(Collider2D other){
		inZone = false;
	}

	void LevelChange (){
		gM = FindObjectOfType<GameManager> ();
		gM.mouseScore++;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
