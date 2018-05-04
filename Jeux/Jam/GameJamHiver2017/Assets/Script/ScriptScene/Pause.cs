using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject Menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown ("m") || Input.GetKeyDown ("joystick button 7")) 
		{
			Vector2 position = new Vector2 (0, 0);
			if (Time.timeScale == 1.0f) {
				Time.timeScale = 0;
				Menu.SetActive(true);

			} else if (Time.timeScale == 0) 
			{
				Time.timeScale = 1;
				Menu.SetActive(false);
			}

		}

		if (Input.GetKeyDown ("n") || Input.GetKeyDown ("joystick button 1")) 
		{
			if (Time.timeScale == 0)
				SceneManager.LoadScene ("MenuPrincipal", LoadSceneMode.Single);
				

		}
		
	}
}
