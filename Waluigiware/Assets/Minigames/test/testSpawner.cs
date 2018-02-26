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
				if (Input.GetKeyDown (KeyCode.Alpha1)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 2) {
				if (Input.GetKeyDown (KeyCode.Alpha2)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 3) {
				if (Input.GetKeyDown (KeyCode.Alpha3)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 4) {
				if (Input.GetKeyDown (KeyCode.Alpha4)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 5) {
				if (Input.GetKeyDown (KeyCode.Alpha5)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 6) {
				if (Input.GetKeyDown (KeyCode.Alpha6)) {
					Instantiate (block, transform.position, Quaternion.identity);
					blockTotal--;
				}
			}
			if (blockNumber == 7) {
				if (Input.GetKeyDown (KeyCode.Alpha7)) {
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
