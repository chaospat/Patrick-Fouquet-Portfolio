using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("GameController").GetComponent<GameManager>().gameState == GameManager.State.Playing)
			transform.Translate (Vector3.down * speed * Time.deltaTime);

	}
}
