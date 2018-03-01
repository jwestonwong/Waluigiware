using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpawner : MonoBehaviour {

	public GameObject block;

	public int blockNumber;

	public static int blockTotal = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (blockTotal > 0) {

			if (blockNumber == 1) {
				if (Input.GetKeyDown (KeyCode.Q)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 2) {
				if (Input.GetKeyDown (KeyCode.W)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 3) {
				if (Input.GetKeyDown (KeyCode.E)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 4) {
				if (Input.GetKeyDown (KeyCode.A)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 5) {
				if (Input.GetKeyDown (KeyCode.S)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 6) {
				if (Input.GetKeyDown (KeyCode.D)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 7) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
		}
	}

	public void Refresh(){
		blockTotal = 10;
	}
}
