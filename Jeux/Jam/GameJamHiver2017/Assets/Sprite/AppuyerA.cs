using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppuyerA : MonoBehaviour {

	// Use this for initialization
	GameManager state;
	void Start () {
		state = GameObject.Find ("GameController").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state.gameState) {
		case GameManager.State.Playing:
			GetComponent<SpriteRenderer> ().enabled = false;
			break;
		default:
			GetComponent<SpriteRenderer> ().enabled = true;
			break;


		}
		
	}
}
