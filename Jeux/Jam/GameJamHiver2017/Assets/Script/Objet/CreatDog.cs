using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatDog : MonoBehaviour {
	public float timeBeteweenDog = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("GameController").GetComponent<GameManager> ().gameState == GameManager.State.Playing) {
			if (timeBeteweenDog != -1) {
				timeBeteweenDog -= Time.deltaTime;
				if (timeBeteweenDog <= 0)
					timeBeteweenDog = -1;

			}

			if (timeBeteweenDog == -1) {


				Vector2 position = new Vector2 (0, 1);
				Vector2 position2 = new Vector2 (GameObject.Find ("Police").transform.position.x + Random.Range (-7.0f, 7.0f), GameObject.Find ("Police").transform.position.y);

				GameObject NewChien = Instantiate (Resources.Load ("PoliceDog_Alone"), position2, Quaternion.identity) as GameObject;
				NewChien.GetComponent<Rigidbody2D> ().AddForce (position * 150);
				NewChien.GetComponent<Animator> ().SetFloat ("VerticalSpeed", 1);
				timeBeteweenDog = 5;


				
			}
		}
		}
	}

