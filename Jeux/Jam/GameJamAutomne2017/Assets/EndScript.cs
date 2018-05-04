using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScript : MonoBehaviour {


	public Text GameOverText;
	private int score = ScoreTrackerScript.ProtectionScore +ScoreTrackerScript.level2Score + ScoreTrackerScript.level3Score ;

	// Use this for initialization
	void Start () {
		GameOverText.text = "Votre Score: "+ score;
	}
	
	// Update is called once per frame
	void Update()
	{
		Time.timeScale = 1;
		if (Input.GetKeyDown(KeyCode.Return)) {
			
			Application.Quit();
		}


	}
}
