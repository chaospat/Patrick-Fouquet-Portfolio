using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Mouvement : MonoBehaviour {
	
	public float mouvementSpeed;
	private Rigidbody2D rb;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		Vector2 vecForce = new Vector2 (-mouvementSpeed*100, 0);
		rb.AddForce (vecForce);
	}
	
	void FixedUpdate() {
	}
			
	} 