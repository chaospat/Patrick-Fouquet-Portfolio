﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("joystick button 0"))
			SceneManager.LoadScene ("MenuPrincipal", LoadSceneMode.Single);
		
	}
}