using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkInProgress : MonoBehaviour {

	void Update()
	{

		if (Input.GetKeyDown (KeyCode.Return)) 
		{

			GameOverScript.NiveauFait++;

			ScoreTrackerScript.GameOver = true;
			PlayerController.musee = true;
			BarreDepression.TEST = 1;

			SceneManager.LoadScene ("Scene1Vierge", LoadSceneMode.Single);


			GameObject[] ToHide = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

			foreach (GameObject obj in ToHide) {

				obj.transform.Translate (0, 0, -10);


			}

		}

	}
}
