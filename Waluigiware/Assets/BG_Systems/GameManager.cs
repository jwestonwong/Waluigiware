using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	static GameManager instance = null;
	private int gameIndex;
	private int previousLevel;

	public int mouseScore;
	public int keyboardScore;

	private int totalLevelsPlayed = 0;

	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			LevelChange ();
		}
	}

	public void LevelChange(){
		gameIndex = Random.Range (1, 6);
		if (gameIndex != previousLevel) {
			previousLevel = gameIndex;
			SceneManager.LoadSceneAsync (gameIndex);
			totalLevelsPlayed++;
		} else {
			LevelChange ();
		}
	}
}
