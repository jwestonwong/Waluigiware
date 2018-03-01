using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour {

	public float randomPos;
	private float startTimer;
	private float dropTimer;
	public float droop;

	public GameObject drop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dropTimer = Time.time - startTimer;
		if (dropTimer > droop) {
			Drop ();
			startTimer = Time.time;
		}
	}

	void Drop (){
		randomPos = Random.Range (-3f, 3f);
		Instantiate (drop, new Vector2 ((transform.position.x + randomPos), transform.position.y), Quaternion.identity);
	}
}
