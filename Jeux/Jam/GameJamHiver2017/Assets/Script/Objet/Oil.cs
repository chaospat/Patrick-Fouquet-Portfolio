using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour {
	PlayerController controller;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameController").GetComponent<PlayerController> ();
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "Player1" || collider.name == "Player2") {
			controller.ralentissement (1, collider.name);
		}

	}
}
