using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicycle : MonoBehaviour {

	public float buffer = 0.2f;
	float xmin;
	float xmax;

	float startTime;
	float elapsedTime;

	public float speed = 10f;

	private SpriteRenderer spriteRenderer;
	private TomatoScript ts;

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer> ();

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
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
			Destroy (gameObject);
		}
	}
}
