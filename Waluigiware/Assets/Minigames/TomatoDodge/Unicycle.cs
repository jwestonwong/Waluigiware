using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicycle : MonoBehaviour {

	public float buffer = 0.2f;
	float xmin;
	float xmax;

	float elapsedTime;

	public float speed = 10f;

	private SpriteRenderer spriteRenderer;
	private TomatoScript ts;

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin;
	private bool mouseWon = false;

	private Camera cam;
	private AudioSource aS;

	// Use this for initialization
	void Start () {
		aS = GetComponent<AudioSource> ();
		cam = FindObjectOfType <Camera> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		endWin = Time.time - winTime;
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
			spriteRenderer.flipX = false;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			spriteRenderer.flipX = true;
		}

		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector2 (newX, transform.position.y);
	}

	void OnTriggerStay2D (Collider2D other){
		ts = other.gameObject.GetComponent<TomatoScript> ();
		if (ts.tomatoTrigger == false) {
			Debug.Log ("Hit");
			cam.backgroundColor = new Color32 (239, 138, 98, 255);
			if (aS != null) {
				aS.Play ();
			}
			winTime = Time.time;
			won = true;
			mouseWon = true;
			Destroy (gameObject.GetComponent<SpriteRenderer>());
			Destroy (gameObject.GetComponent<MouseTimer> ());
			Destroy (gameObject.GetComponent<Collider2D> ());
		}
	}

	void LevelChange(){
		gM = FindObjectOfType<GameManager> ();
		if (mouseWon) {
			gM.mouseScore++;
		}
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
