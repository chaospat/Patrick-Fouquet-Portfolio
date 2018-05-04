using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreTrackerScript : MonoBehaviour {



	public static bool GameOver = false;
	private string Nom;

	public static int ProtectionScore  = 0;
	public static int level2Score = 0;
	public static int level3Score = 0;

	private int scoreFinale;

	void Update () { 

		if (GameOver == true) {

			Nom = MenuScript.charName;
			scoreFinale = ProtectionScore + level2Score + level3Score;

			PlayerController.musee = true;
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Score\Score.txt", true))
			{
				file.WriteLine(Nom +": " +scoreFinale );
					
			}



			GameOver = false;

		}


	}

}
