using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittenMove : MonoBehaviour {

	float xmin;
	float xmax;
	float speed = 3f;

	private int direction = 0;

	public float buffer = 1f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 farLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 farRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));
		xmin = farLeft.x + buffer;
		xmax = farRight.x - buffer;
	}
	
	// Update is called once per frame
	void Update () {
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

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Keyboard") {
			Debug.Log ("Kitty Hit");
			Destroy (gameObject);
		}
	}
}
