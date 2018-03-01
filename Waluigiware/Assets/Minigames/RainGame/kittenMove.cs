using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittenMove : MonoBehaviour {

	float xmin;
	float xmax;
	float speed = 3f;

	private int direction = 0;

	public float buffer = 1f;

	float startTimer;
	float elapsedTimer;
	public float endTimer;

	bool beat = false;

	private GameManager gm;
	private Camera cam;
	private AudioSource aS;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 farLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 farRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
		xmin = farLeft.x + buffer;
		xmax = farRight.x - buffer;
		startTimer = Time.time;
		aS = GetComponent<AudioSource> ();
		cam = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		elapsedTimer = Time.time - startTimer;
		if (elapsedTimer >= endTimer) {
			if (beat) {
				gm.LevelChange ();
				beat = false;
			}
		}
					
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Keyboard") {
			Debug.Log ("Mouse Won");
			gm = FindObjectOfType<GameManager> ();
			cam.backgroundColor = new Color32 (239, 138, 98, 255);
			if (aS != null) {
				aS.Play ();
			}
			startTimer = Time.time;
			endTimer = 2f;
			beat = true;
			gm.mouseScore++;
			Destroy (this.GetComponent<SpriteRenderer> ());
			Destroy (this.GetComponent<MouseTimer> ());
		}
	}


	void Movement (){
		if (direction == 0) {
			if (transform.position.x != xmax) {
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else {
				direction++;
			}
		}
		if (direction == 1) {
			if (transform.position.x != xmin) {
				transform.position += Vector3.left * speed * Time.deltaTime;
			} else {
				direction--;
			}
		}
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector2 (newX, transform.position.y);
	}
}
