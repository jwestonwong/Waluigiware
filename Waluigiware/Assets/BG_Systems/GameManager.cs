using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	static GameManager instance = null;
	private int gameIndex;
	private int previousLevel;

	public int mouseScore;
	public int keyboardScore;

	private int totalLevelsPlayed = 0;

	public Text mouse;
	public Text keyboard;

	public bool mouseWon = false;
	public bool keyboardWon = false;

	bool gameEnded = false;

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
		mouse.text = ("Mouse: " + mouseScore);
		keyboard.text = ("Keyboard: " + keyboardScore);

		if (totalLevelsPlayed >= 15) {
			if (mouseScore > keyboardScore) {
				mouseWon = true;
			}
			if (mouseScore < keyboardScore) {
				keyboardWon = true;
			}
			if (gameEnded == false) {
				GameEnd ();
				gameEnded = true;
			}
		}

	}

	public void LevelChange(){
		gameIndex = Random.Range (1, 11);
		if (gameIndex != previousLevel) {
			previousLevel = gameIndex;
			SceneManager.LoadSceneAsync (gameIndex);
			totalLevelsPlayed++;
		} else {
			LevelChange ();
		}
	}

	public void GameEnd(){
		SceneManager.LoadSceneAsync ("End");
	}
}
