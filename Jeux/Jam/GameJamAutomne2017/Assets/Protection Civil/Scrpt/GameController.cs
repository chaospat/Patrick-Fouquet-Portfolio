using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int nbWave = 5;
	public int score = 0;
	public int vieCivil = 100;
	public int finalScore;
	public Text scoreText;
	public Text civilText;
	public Text restartText;
	public Text gameOverText;
	private SpriteRenderer sprite;

	public bool gameOver;

	// Use this for initialization
	void Start () {
//		restartText.text = "";
		gameOverText.text = "";
		finalScore = 0;
	
		UpdateScore();
		UpdateVieCivil();

	}

	public void GameOver(){
		finalScore = score + score * vieCivil/2;
		gameOverText.text = "Score final : " + finalScore +"\n Appuyez sur ENTER pour continuer";
		gameOver = true;

	}

	public void AddScore(int addScore){
		score += addScore;
		UpdateScore();
	}

	public void dmgCivil(int dmg){
		vieCivil -= dmg;
		UpdateVieCivil();

		if (vieCivil <= 0)
			GameOver ();
	}

	void UpdateScore(){
		scoreText.text = "Score : " + score;
	}

	void UpdateVieCivil(){
		civilText.text = "Civil : " + vieCivil;
	}


	void Update()
	{

		if (Input.GetKeyDown (KeyCode.Return) && gameOver == true) 
		{
			GameOverScript.NiveauFait++;
			ScoreTrackerScript.ProtectionScore = finalScore;

			PlayerController.musee = true;

			BarreDepression.TEST = 1;

			GameObject[] ToHide = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

			foreach (GameObject obj in ToHide) {

				obj.transform.Translate (0, 0, -10);


			}

			SceneManager.LoadScene ("Scene1Vierge", LoadSceneMode.Single);

				
		
		}

	}
}
