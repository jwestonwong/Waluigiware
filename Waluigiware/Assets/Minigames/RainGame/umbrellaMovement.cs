using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbrellaMovement : MonoBehaviour {

	public float buffer = 0.2f;
	float xmin;
	float xmax;

	float elapsedTime;

	public float speed = 10f;
	private float thrust = 8f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;

	}

	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement(){
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (transform.right * thrust);
		} else if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (-transform.right * thrust);
		} else {
			rb.velocity = new Vector2 (0,0);
		}

		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector2 (newX, transform.position.y);
	}
}
