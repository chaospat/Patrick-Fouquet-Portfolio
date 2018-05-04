using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class introText : MonoBehaviour {


    void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 7"))
			SceneManager.LoadScene ("Scene", LoadSceneMode.Single);
	}


}
