using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("joystick button 0"))
			SceneManager.LoadScene ("intro", LoadSceneMode.Single);
		if (Input.GetKeyDown ("joystick button 1"))
			Application.Quit();
		if (Input.GetKeyDown ("joystick button 2"))
			SceneManager.LoadScene ("HowToPlay", LoadSceneMode.Single);
		
	}
}
