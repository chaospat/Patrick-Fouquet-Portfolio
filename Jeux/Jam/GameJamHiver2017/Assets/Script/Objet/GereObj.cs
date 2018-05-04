using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GereObj : MonoBehaviour {

    string ObjectsName;
	public float TimeToWait = -1;
	PlayerController gameManager;
	public float distance=10;
	public string buttonname;
	public string AxisNameX;
	public string AxisNameY;
	public float speed;

	public AudioSource audioCouteau;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameController").GetComponent<PlayerController>();
		if (gameObject.name == "Player1") {
			buttonname = "P1_Fire1";
			AxisNameX = "P1_Horizontal_J2";
			AxisNameY = "P1_Vertical_J2";
		} else if (gameObject.name == "Player2") 
		{
			buttonname = "P2_Fire1";
			AxisNameX = "P2_Horizontal_J2";
			AxisNameY = "P2_Vertical_J2";
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
		Pickable temp = coll.gameObject.GetComponent<Pickable> ();
		if (temp != null) {
			ObjectsName = temp.Pick();
			if (gameObject.name == "Player1") {
				GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().SetArme (ObjectsName);
			} else if (gameObject.name == "Player2") {
				GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().SetArme (ObjectsName);

			}
			if (temp is Seringue) {
				//gameManager.boost (2,gameObject.name);
			}
		}
		Lancer temp2 = coll.gameObject.GetComponent<Lancer> ();
		if (temp2 != null) 
		{
			temp2.Hit (gameManager, gameObject.name,this);

		}

	
    }
		
    // Update is called once per frame
    void Update () {

		Vector2 position = new Vector2 (Input.GetAxis (AxisNameX)*10f, Input.GetAxis (AxisNameY)*10f);
		position = position.normalized;
		if (position == Vector2.zero)
			position = new Vector2 (0, -1);

		if (TimeToWait != -1) {
			TimeToWait -= Time.deltaTime;
			if (TimeToWait <= 0) {
				gameObject.GetComponent<Rigidbody2D> ().mass = 1;
				TimeToWait = -1;
				if (gameObject.name == "Player1") {
					GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().setEffect ("");
				} else if (gameObject.name == "Player2") {
					GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().setEffect ("");

				}
			}
		}

		if (Input.GetAxis(buttonname)<0) 
		{
			float rot_z = Mathf.Atan2 (position.y, position.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.Euler(0f, 0f, rot_z);
			switch (ObjectsName) 
			{

			case "Couteau":
				
				GameObject NewCouteau = Instantiate (Resources.Load ("CouteauLancee"), transform.position, rotation) as GameObject;
				NewCouteau.GetComponent<CouteauLancee> ().owner = gameObject.name;
				NewCouteau.GetComponent<Rigidbody2D> ().velocity = position * speed;
				break;

			case "Os":

				GameObject NewOs = Instantiate (Resources.Load ("OsLancee"), transform.position, rotation) as GameObject;
				NewOs.GetComponent<OsLancee> ().owner = gameObject.name;
				NewOs.GetComponent<Rigidbody2D> ().velocity = position * speed;
				break;
	
			case"Pills":
				TimeToWait = 3;
				gameObject.GetComponent<Rigidbody2D> ().mass = 3;
				if (gameObject.name == "Player1") {
					GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().setEffect ("PowerUp");
				} else if (gameObject.name == "Player2") {
					GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().setEffect ("PowerUp");

				}
				break;

			case"Seringue":
				gameManager.boost (2, gameObject.name);
				if (gameObject.name == "Player1") {
					GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().setEffect ("vitesseUP");
				} else if (gameObject.name == "Player2") {
					GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().setEffect ("vitesseUP");

				}
				break;
			default:
				break;


			}
			ObjectsName = "";
			if (gameObject.name == "Player1") {
				GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().SetArme (ObjectsName);
			} else if (gameObject.name == "Player2") {
				GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().SetArme (ObjectsName);

			}

		}
	}
}
