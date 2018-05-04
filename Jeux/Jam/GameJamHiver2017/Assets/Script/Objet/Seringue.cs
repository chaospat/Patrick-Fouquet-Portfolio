using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seringue : MonoBehaviour, Pickable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public string Pick(){
		Destroy (gameObject);
		return "Seringue";

	}
}
