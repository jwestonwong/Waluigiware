using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyBowlController : MonoBehaviour {

	public float buffer = 1f;
	float xmin;
	float xmax;
	float ymin;
	float ymax;

	float speed = 6f;

	public int keyScore;
	public Text text;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
		ymin = bottomLeft.y + buffer;
		ymax = topRight.y - buffer;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		text.text = keyScore.ToString();
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

	void OnTriggerStay2D (Collider2D other){
		Destroy (other.gameObject);
		keyScore++;
	}
}
