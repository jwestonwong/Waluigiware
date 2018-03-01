using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour {

	public float buffer = 0.2f;
	float xmin;
	float xmax;
	float ymin;
	float ymax;

	float startTime;
	float elapsedTime;
	float clickTimer;

	public Collider2D coll;
	public Rigidbody2D rb;

	private GameManager gm;

	public float speed = 10f;

	private bool won = false;
	private float winTime;
	private float endWin = 2f;

	private AudioSource audio;
	private Camera cam;

	// Use this for initialization
	void Start () {
		coll = gameObject.GetComponent<Collider2D> ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
		cam = FindObjectOfType<Camera> ();

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
		ymin = bottomLeft.y + buffer;
		ymax = topRight.y - buffer;
		startTime = Time.time;
		clickTimer = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		endWin = Time.time - winTime;
		Movement ();
		if (Input.GetMouseButtonDown (0)) {
			coll.isTrigger = true;
			rb.simulated = true;
			startTime = Time.time;
		}
		elapsedTime = Time.time - startTime;
		if (elapsedTime >= clickTimer) {
			coll.isTrigger = false;
			rb.simulated = false;
		}

		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
				won = false;
			}
		}

	}

	void Movement(){
		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		float newY = Mathf.Clamp (transform.position.y, ymin, ymax);
		transform.position = new Vector2 (newX, newY);

	}

	void OnTriggerEnter2D (Collider2D other){
		Debug.Log ("Bug Caught");
		audio.Play ();
		cam.backgroundColor = new Color32 (239, 138, 98, 255);
		Destroy (gameObject.GetComponent<SpriteRenderer>());
		Destroy (gameObject.GetComponent<MouseTimer>());
		winTime = Time.time;
		won = true;
	}

	void LevelChange (){
		gm = FindObjectOfType<GameManager> ();
		gm.mouseScore++;
		gm.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
