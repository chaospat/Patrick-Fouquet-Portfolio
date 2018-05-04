using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public SpriteRenderer spriteCanvas;
	public Sprite[] winSprite;
	public Sprite[] countDown;
	// Use this for initialization
	public enum State{
		Playing=1,
		WinPlayer1=2,
		WinPlayer2=3,
		GameStarting=4,
		WaitingForPlayer=5
	}

	//[HideInInspector]
	public State gameState;
	private float timeBeforeStart = -1;
	public Text text;
	void Start () {
		gameState = State.WaitingForPlayer;	
		spriteCanvas.sprite = null;
		//Time.timeScale = 0;
		//text = GameObject.Find ("Countdown").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState){
		case State.WaitingForPlayer:
			if (Input.GetButton ("ButtonA1")) {
				GameObject.Find ("Rdy1").GetComponent<SpriteRenderer> ().color = Color.green;
			}
			else
				GameObject.Find ("Rdy1").GetComponent<SpriteRenderer> ().color = Color.red;
			if (Input.GetButton ("ButtonA2")) {
				GameObject.Find ("Rdy2").GetComponent<SpriteRenderer> ().color = Color.green;
			}
			else
				GameObject.Find ("Rdy2").GetComponent<SpriteRenderer> ().color = Color.red;
			if (Input.GetButton ("ButtonA1") && Input.GetButton ("ButtonA2")) {
				gameState = State.GameStarting;
				timeBeforeStart = 4;
				Time.timeScale = 1;
			}
			break;
		case State.GameStarting:
			timeBeforeStart -= Time.deltaTime; 
			if (timeBeforeStart > 3) {
				spriteCanvas.sprite = countDown [3];
			} else if (timeBeforeStart > 2) {
				spriteCanvas.sprite = countDown [2];
			} else if (timeBeforeStart > 1) {
				spriteCanvas.sprite = countDown [1];
			} else if (timeBeforeStart > 0) {
				spriteCanvas.sprite = countDown [0];
			}
			if (timeBeforeStart <= 0.5) {
				gameState = State.Playing;
				GameObject.Find ("Rdy2").SetActive (false);
				GameObject.Find ("Rdy1").SetActive (false);
				gameObject.GetComponent<PlayerController> ().startFalling ();
				spriteCanvas.sprite = null;
			}
			
			break;
		case State.WinPlayer1:
			spriteCanvas.sprite = winSprite[0];
			if (Input.GetButton ("ButtonA1"))
				SceneManager.LoadSceneAsync ("Scene");
			break;
		case State.WinPlayer2:
			spriteCanvas.sprite = winSprite[1];
			if (Input.GetButton ("ButtonA2"))
				SceneManager.LoadSceneAsync ("Scene");
			break;
		default:
			break;
		}

	}


	public void playerWin(int num){
		if (num == 1) {
			gameState = State.WinPlayer1;

		} else if (num == 2) {
			gameState = State.WinPlayer2;

		}
	}
}
