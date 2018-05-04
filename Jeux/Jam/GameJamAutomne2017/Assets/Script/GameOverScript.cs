using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour {


	public static float fill;
	public static int NiveauFait = 0;
	public GameObject Barre;
	private int score;

	
	// Update is called once per frame
	void Update () {

		fill = BarreDepression.fillAmount;
	
		if (fill <= 0.1 ) {

			GameOver ();
			Time.timeScale = 0;

		}

		if (NiveauFait == 3) {
			GameOver ();
			Time.timeScale = 0;
		}

	}

	public void GameOver(){


		score = ScoreTrackerScript.ProtectionScore + ScoreTrackerScript.level2Score + ScoreTrackerScript.level3Score;

		if (score >= 20000)
			SceneManager.LoadScene ("Fin", LoadSceneMode.Single);
		else
			SceneManager.LoadScene ("FinBAD", LoadSceneMode.Single);


	}
}
