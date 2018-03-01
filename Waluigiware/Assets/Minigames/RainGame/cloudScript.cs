using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudScript : MonoBehaviour {

	public GameObject drop;

	public float randomPos;

	private float startTimer;
	private float dropTimer;

	public float buffer = 0.5f;
	float xmin;
	float xmax;
	float ymin;
	float ymax;

	// Use this for initialization
	void Start () {
		startTimer = Time.time;

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0.7f, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
		ymin = bottomLeft.y + buffer/2;
		ymax = topRight.y - buffer/2;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float newX = Mathf.Clamp (mousePOS.x, xmin, xmax);
		float newY = Mathf.Clamp (mousePOS.y, ymin, ymax);
		transform.position = new Vector2 (newX, newY);

		dropTimer = Time.time - startTimer;
		if (dropTimer > 0.6f) {
			Rain ();
			startTimer = Time.time;
		}
	}

	void Rain (){
		randomPos = Random.Range (-0.6f, 0.6f);
		Instantiate (drop, new Vector2 ((transform.position.x + randomPos), transform.position.y), Quaternion.identity);
	}
}
