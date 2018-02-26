using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoToss : MonoBehaviour {

	public GameObject tomato;

	public float shotTime;
	public float delayTime;
	public float targetTime = 0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		delayTime = Time.time - shotTime;
		if (delayTime >= targetTime) {
			if (Input.GetMouseButtonDown (0)) {
				Instantiate (tomato, transform.position, Quaternion.identity);
				shotTime = Time.time;
			}
		}
	}
}
