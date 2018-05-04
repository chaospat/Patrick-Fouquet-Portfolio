using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseGame : MonoBehaviour {

	public Transform canvas;
	// Use this for initialization

	void Start()
	{

		canvas.gameObject.SetActive (false);

	}
	void Update  () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
		
			Pause ();
		
		}

		
	}
	
	// Update is called once per frame
	public void Pause () {
		
			if (canvas.gameObject.activeInHierarchy == false) {

				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
			} else {

				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
			}






	}


}
