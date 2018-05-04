using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarreChargementReactor : MonoBehaviour {

	static Image Barre; 
	public Text gameOverText;

	public float max { get; set;}

	private float WaitForUpdate;

	public float overLoadRate;
	public float water;
	public float numberOfConnection;

	public Tuyau_Tournant rotatingTunnelA;
	public Tuyau_TournantB rotatingTunnelB; 
	public Tuyau_TournantC rotatingTunnelC;
	public Tuyau_TournantD rotatingTunnelD;

	private int score;

	public bool a, b,c,d; 

	private bool gameOver = false;

	private float Valeur; 
	public float valeur{	get	{return Valeur;}
		set
		{
			Valeur = Mathf.Clamp(value,0,max);
			Barre.fillAmount = (1/max)*Valeur;
		}
	}
	// Use this for initialization
	void Start () {
		Barre = GetComponent<Image>();
		max = 100;
		valeur=0;
	}
	
	// Update is called once per frame

	void Update () {
		if (Valeur == 100) {
			score = 0;

			GameOver ();
		}

		if (a == true && b == true && c == true && d == true && !rotatingTunnelA.touch && !rotatingTunnelB.touch && !rotatingTunnelC.touch&& !rotatingTunnelD.touch) {
			score = (100 - (int)Valeur) * 300;

			GameOver ();

		}

		if (a == true && water != 1) {
			water = 1;		
		}

		if (a == false && water == 1) {
			water = 0;
		}

		if (b == true) {
			if(c == true ){
				if (d == true && numberOfConnection !=2) {
					numberOfConnection = 2;
				} else if(numberOfConnection != 1 && d == false) {
					numberOfConnection = 1;
				}
			}else if (numberOfConnection != 1){
				numberOfConnection = 1;
			}
		}

		if (b == false) {
			if (c == false && numberOfConnection !=0|| d == false && numberOfConnection !=0) {
				numberOfConnection = 0;
			} else if (numberOfConnection !=1 && c== true && d==true){
				numberOfConnection = 1;}}

		if (b == false && c == false && d == false && numberOfConnection != 0 ){
			numberOfConnection = 0;
		}

		if (Valeur != 100 && Time.time > WaitForUpdate + water + numberOfConnection/3) {
			WaitForUpdate = Time.time + (overLoadRate*2);
			valeur += 5;
		}

		if (Input.GetKeyDown (KeyCode.Return) && gameOver == true) 
		{
			GameOverScript.NiveauFait++;
			ScoreTrackerScript.level2Score = score;
			ScoreTrackerScript.GameOver = true;
			PlayerController.musee = true;


			GameObject[] ToHide = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

			foreach (GameObject obj in ToHide) {

				obj.transform.Translate (0, 0, -10);


			}
			Time.timeScale = 1;
			SceneManager.LoadScene ("Scene1Vierge", LoadSceneMode.Single);



		}

		
	}


	public void GameOver(){


		gameOverText.text = "Score final : " + score +"\n Appuyez sur ENTER pour continuer";
		gameOver = true;

		BarreDepression.TEST = 1;
		Time.timeScale = 0;

	}
}
