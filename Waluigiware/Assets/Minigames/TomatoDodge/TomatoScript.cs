using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoScript : MonoBehaviour {

	private float startTime;
	private float endTime = 2f;
	private float elapsedTime;
	private float destroyTime = 2.2f;

	private float newSize;
	private float newScale;

	private float endScale = 0.5f;
	private float destroyScale = 0.6f;

	public bool tomatoTrigger = true;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = Time.time - startTime;

		if (elapsedTime < endTime) {
			newSize = ((elapsedTime / endTime) * endScale);
			newScale = 1f - newSize;
			transform.localScale = new Vector3 (newScale, newScale, this.transform.localScale.z);
		} else if (elapsedTime < destroyTime) {
			tomatoTrigger = false;
			newSize = ((elapsedTime / destroyTime) * destroyScale);
			newScale = 1f - newSize;
			transform.localScale = new Vector3 (newScale, newScale, this.transform.localScale.z);
		}
		if (elapsedTime > destroyTime) {
			Destroy (gameObject);
		}
	}
}
