using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public Vector3 playerOnePosition = new Vector3 (-1, 0, 0);
	public Vector3 playerTwoPosition = new Vector3 (1, 0, 0);

	public float TimeToWait1 = -1;
	public float TimeToWait2 = -1;//variable pour le temps d'attente
	public float timeToDash = 1; //Dash en seconde
	public float DashDistance = 10;
	public float DashCoolDown = 5;
	public bool playerOnecanDash;
	public bool playerTwocanDash;
	 

	float currentTimeDashing1 = -1 ;
	float currentTimeDashing2 = -1;
	float currentTimeCdDash1 = 0;
	float currentTimeCdDash2 = 0;
	Vector3 targetDash1;
	Vector3 targetDash2;
	//The CharacterControllers
	public GameObject playerOne;
	public GameObject playerTwo;

	public float speedP1_Ratio = 1;
	public float speedP2_Ratio = 1;

	public float speed = 2;
	public float speedFall = -5;

	Animator animation1;
	Animator animation2;
	GameManager gameManager;
	public Boundary boundary;

	void Start(){
		animation1 = playerOne.GetComponent<Animator> ();
		animation2 = playerTwo.GetComponent<Animator> ();
		gameManager = GameObject.Find ("GameController").GetComponent<GameManager> ();

	}
	public void startFalling(){
		playerOne.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speedFall, 0);
		playerTwo.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speedFall, 0);
	}

	void playerMove(){
		//Debug.Log (currentTimeCdDash1);
		//Mouvement Player 1////

		if (Input.GetAxis ("P1_Fire1") > 0) {
			if (playerOnecanDash) {
				targetDash1 = new Vector3 (Input.GetAxis ("P1_Horizontal"), Input.GetAxis ("P1_Vertical"), 0);
				targetDash1 = playerOne.transform.position + targetDash1.normalized * DashDistance;
				currentTimeDashing1 = timeToDash;
				playerOnecanDash = false;
				currentTimeCdDash1 = DashCoolDown;
				animation1.SetBool ("Dashing", true);
				GameObject.Find ("BarreP1").GetComponent<Animator> ().SetBool ("DashUse", true);

			}

		}
		if (currentTimeDashing1 == -1) {
			currentTimeCdDash1 -= Time.deltaTime;
			if (currentTimeCdDash1 <= 0)
				playerOnecanDash = true;
			Vector3 test = new Vector3 (Input.GetAxis ("P1_Horizontal"), Input.GetAxis ("P1_Vertical"), 0);
			test = test.normalized * speed * Time.deltaTime * speedP1_Ratio;

			//playerOnePosition *= temp*speedP1_Ratio;
			playerOnePosition = test + playerOne.transform.position;

			playerOnePosition.x = Mathf.Clamp (playerOnePosition.x, boundary.xMin, boundary.xMax);
			playerOnePosition.y = Mathf.Clamp (playerOnePosition.y, boundary.yMin, boundary.yMax);

			if (Mathf.Abs (Input.GetAxis ("P1_Vertical")) >= Mathf.Abs (Input.GetAxis ("P1_Horizontal"))) {
				animation1.SetFloat ("VerticalSpeed", Input.GetAxis ("P1_Vertical"));
				animation1.SetFloat ("HorizontalSpeed", 0);
			} else {
				animation1.SetFloat ("HorizontalSpeed", Input.GetAxis ("P1_Horizontal"));
				animation1.SetFloat ("VerticalSpeed", 0);
			}
		} else {
			playerOnePosition = Vector3.Lerp (playerOne.transform.position, targetDash1, 0.09f);
			currentTimeDashing1 -= Time.deltaTime;
			if (currentTimeDashing1 <= 0) {
				currentTimeDashing1 = -1;
				animation1.SetBool ("Dashing", false);
				GameObject.Find ("BarreP1").GetComponent<Animator> ().SetBool ("DashUse", false);
			}



		}
		//Mouvement Player 2
		//playerTwoPosition = new Vector3(Input.GetAxis ("P2_Horizontal"), Input.GetAxis ("P2_Vertical"),0.0f);
		if (Input.GetAxis ("P2_Fire1") > 0) {
			if (playerTwocanDash) {
				targetDash2 = new Vector3 (Input.GetAxis ("P2_Horizontal"), Input.GetAxis ("P2_Vertical"), 0);
				targetDash2 =  playerTwo.transform.position + targetDash2.normalized * DashDistance;
				currentTimeDashing2 = timeToDash;
				playerTwocanDash = false;
				currentTimeCdDash2 = DashCoolDown;
				animation2.SetBool ("Dashing", true);
				GameObject.Find ("BarreP2").GetComponent<Animator> ().SetBool ("DashUse", true);
			}

		}
		if (currentTimeDashing2 == -1) {
			//temp = Mathf.Sqrt (Input.GetAxis ("P2_Horizontal") * Input.GetAxis ("P2_Horizontal") + Input.GetAxis ("P2_Vertical") * Input.GetAxis ("P2_Vertical"));
			currentTimeCdDash2 -= Time.deltaTime;
			if (currentTimeCdDash2 <= 0)
				playerTwocanDash = true;
			Vector3 test = new Vector3 (Input.GetAxis ("P2_Horizontal"), Input.GetAxis ("P2_Vertical"), 0);
			test = test.normalized * speed * Time.deltaTime * speedP2_Ratio;
			//temp *= Time.deltaTime * speed;
			//playerTwoPosition *= temp*speedP2_Ratio;
			playerTwoPosition = test + playerTwo.transform.position;

			playerTwoPosition.x = Mathf.Clamp (playerTwoPosition.x, boundary.xMin, boundary.xMax);
			playerTwoPosition.y = Mathf.Clamp (playerTwoPosition.y, boundary.yMin, boundary.yMax);

			if (Mathf.Abs (Input.GetAxis ("P2_Vertical")) >= Mathf.Abs (Input.GetAxis ("P2_Horizontal"))) {
				animation2.SetFloat ("VerticalSpeed", Input.GetAxis ("P2_Vertical"));
				animation2.SetFloat ("HorizontalSpeed", 0);
			} else {
				animation2.SetFloat ("HorizontalSpeed", Input.GetAxis ("P2_Horizontal"));
				animation2.SetFloat ("VerticalSpeed", 0);
			}
		}else{
			playerTwoPosition = Vector3.Lerp (playerTwo.transform.position, targetDash2, 0.09f);
			currentTimeDashing2 -= Time.deltaTime;
			if (currentTimeDashing2 <= 0) {
				currentTimeDashing2 = -1;
				animation2.SetBool ("Dashing", false);
				GameObject.Find ("BarreP2").GetComponent<Animator> ().SetBool ("DashUse", false);
			}

		}
		playerOne.transform.position = playerOnePosition;
		playerTwo.transform.position = playerTwoPosition;

		playerOne.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speedFall, 0);
		playerTwo.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speedFall, 0);
	}

	void Update()
	{
		


		if (gameManager.gameState == GameManager.State.Playing) {
			playerTwo.transform.position = new Vector3(playerTwo.transform.position.x,playerTwo.transform.position.y,-1);
			if (playerOne.transform.position.y > playerTwo.transform.position.y) {
				playerOne.transform.position = new Vector3(playerOne.transform.position.x,playerOne.transform.position.y,0);
			} else
				playerOne.transform.position = new Vector3(playerOne.transform.position.x,playerOne.transform.position.y,-2);
			if (TimeToWait1 != -1) {
				TimeToWait1 -= Time.deltaTime;
				if (TimeToWait1 <= 0) {
					speedP1_Ratio = 1;
					TimeToWait1 = -1;
						GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().setEffect("");
				}
					
			}

			if (TimeToWait2 != -1) {
				TimeToWait2 -= Time.deltaTime;
				if (TimeToWait2 <= 0) {
					speedP2_Ratio = 1;
					TimeToWait2 = -1;
					GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().setEffect ("");

				}
			}
		}


	}

	void FixedUpdate ()
	{

		if(gameManager.gameState == GameManager.State.Playing)
			playerMove();
	}

	public void ralentissement(float temps, string  player)
	{
		if (player == "Player1") 
		{
			speedP1_Ratio = 0.25f;
			TimeToWait1 = temps;
		}
		else if (player == "Player2") 
		{
			speedP2_Ratio = 0.25f;
			TimeToWait2 = temps;
		}


	}
	public void boost(float temps,string player){
		
			if (player == "Player1") 
			{
				speedP1_Ratio = 1.5f;
				TimeToWait1 = temps;
			}
			else if (player == "Player2") 
			{
				speedP2_Ratio = 1.5f;
				TimeToWait2 = temps;
			}


		}

}
