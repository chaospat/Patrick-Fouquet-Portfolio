using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

	public float timeUntilDestroy = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilDestroy -= Time.deltaTime;
		if (timeUntilDestroy <= 0)
			Destroy (gameObject);
	}
}
