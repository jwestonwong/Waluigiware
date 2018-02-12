using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour {

	public int[] buttonOrder;
	int buttonOrderFiller;
	int arrayPos;

	public Text prompt;

	private GameManager gM;
	private bool won = false;
	private float winTime;
	private float endWin = 1f;

	// Use this for initialization
	void Start () {
		buttonOrderFiller = 0;
		arrayFill ();
		arrayPos = 0;
		//prompt = FindObjectOfType<Text> ();
		}
	
	// Update is called once per frame
	void Update () {
		if (arrayPos == 10) {
			Debug.Log ("Subway wins!");
			prompt.text = "Subway Wins!";
			winTime = Time.time;
			won = true;
			arrayPos++;
		} else if (arrayPos < 10) {
			prompt.text = (buttonOrder[arrayPos]).ToString();
		}
		endWin = Time.time - winTime;
		if (won) {
			if (endWin >= 2f) {
				LevelChange ();
				won = false;
			}
		}
	}

	void arrayFill (){
		buttonOrder[buttonOrderFiller] = Random.Range (1, 6);
		buttonOrderFiller++;

		if (buttonOrderFiller <= 9) {
			arrayFill();
		}
	}

	public void ButtonPress1 (){
		if ((buttonOrder [arrayPos]) == 1) {
			arrayPos++;
		}
	}

	public void ButtonPress2(){
		if ((buttonOrder [arrayPos]) == 2) {
			arrayPos++;
		}
	}

	public void ButtonPress3(){
		if ((buttonOrder [arrayPos]) == 3) {
			arrayPos++;
		}
	}

	public void ButtonPress4(){
		if ((buttonOrder [arrayPos]) == 4) {
			arrayPos++;
		}
	}

	public void ButtonPress5(){
		if ((buttonOrder [arrayPos]) == 5) {
			arrayPos++;
		}
	}

	void LevelChange (){
		gM = FindObjectOfType<GameManager> ();
		gM.keyboardScore++;
		gM.LevelChange ();
		Debug.Log ("LevelChange");
	}
}
