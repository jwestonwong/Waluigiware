using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pogoMovement : MonoBehaviour {

	public float buffer = 0.6f;
	float xmin;
	float xmax;

	private Rigidbody2D rb;
	private GameManager gM;

	public float speed = 8f;
	public float jumpHeight = 10f;

	private bool won = false;
	private float winTime;
	private float endWin = 2f;

	private AudioSource auPlayer;
	public AudioClip jump;
	public AudioClip win;

	private Camera cam;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
		rb = GetComponent<Rigidbody2D> ();
		auPlayer = GetComponent<AudioSource> ();
		cam = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		endWin = Time.time - winTime;
		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector2 (newX, transform.position.y);

		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
				won = false;
			}
		}

	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Obstacle") {
			rb.velocity = new Vector2 (0, jumpHeight);
			auPlayer.clip = jump;
			auPlayer.Play ();
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Mouse") {
			Debug.Log ("Mouse Wins");
			auPlayer.clip = win;
			auPlayer.Play ();
			cam.backgroundColor = new Color32 (239, 138, 98, 255);
			Destroy (this.GetComponent<Collider2D> ());
			Destroy (this.GetComponent<MouseTimer> ());
			winTime = Time.time;
			won = true;
		}
	}

	void LevelChange (){
		gM = FindObjectOfType<GameManager> ();
		gM.mouseScore++;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
