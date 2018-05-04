using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceDog_Alone : MonoBehaviour {

	GameManager gameManager;

	public float positionFinal = 8;


	void Start()
	{
		gameManager = GameObject.Find ("GameController").GetComponent<GameManager> ();

	}

	void Update()
	{

		if (transform.position.y > positionFinal)
			Destroy (gameObject);

	}


	void OnTriggerEnter2D (Collider2D collider)  {
		if (collider.gameObject.tag == "Player1") {
			gameManager.gameState = GameManager.State.WinPlayer2;
			Time.timeScale = 0;
		} else if (collider.gameObject.tag == "Player2") {
			gameManager.gameState = GameManager.State.WinPlayer1;
			Time.timeScale = 0;
		} else if ((collider.gameObject.tag == "Mur")) {
			Destroy (gameObject);
		} else if ((collider.gameObject.tag == "OsLancee")) {
			Destroy (gameObject);
		} else if ((collider.gameObject.tag == "Bed"))
			Destroy (collider.gameObject);
			
	}
}
