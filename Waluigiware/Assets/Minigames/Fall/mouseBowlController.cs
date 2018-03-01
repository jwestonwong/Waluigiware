using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseBowlController : MonoBehaviour {

	public float buffer = 0.5f;
	float xmin;
	float xmax;
	float ymin;
	float ymax;

	public int mousescore;
	public Text text;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0, distance));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, distance));
		xmin = bottomLeft.x + buffer;
		xmax = topRight.x - buffer;
		ymin = bottomLeft.y + buffer;
		ymax = topRight.y - buffer;
	}

	// Update is called once per frame
	void Update () {
		Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float newX = Mathf.Clamp (mousePOS.x, xmin, xmax);
		float newY = Mathf.Clamp (mousePOS.y, ymin, ymax);
		transform.position = new Vector2 (newX, newY);

		text.text = mousescore.ToString();
	}

	void OnTriggerStay2D (Collider2D other){
		Destroy (other.gameObject);
		mousescore++;
	}
}
