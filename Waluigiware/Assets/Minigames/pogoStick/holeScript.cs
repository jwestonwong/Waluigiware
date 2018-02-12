using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeScript : MonoBehaviour {

	public float buffer = 0.5f;
	float xmin;
	float xmax;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
	}

	// Update is called once per frame
	void Update () {
		Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float newX = Mathf.Clamp (mousePOS.x, xmin, xmax);
		transform.position = new Vector2 (newX, transform.position.y);
	}
}
