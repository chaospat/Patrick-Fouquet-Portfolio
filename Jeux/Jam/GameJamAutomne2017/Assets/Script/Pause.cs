using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	bool isPause = false;

	public Rect windowRect = new Rect(800, 100, 800, 600);
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Escape))
		{
			isPause = !isPause;
			if(isPause)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}

	void OnGUI()
	{
		if(isPause)
			GUI.Window(0, windowRect, DoMyWindow, "Pause Menu");
	}

	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (50, 50, 300, 50), "Resume")) {
			isPause = !isPause;
			Time.timeScale = 1;
		}
			
		if (GUI.Button (new Rect (50, 120, 300, 50), "Menu")) {

			GameObject[] Todelete = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
			foreach(GameObject enemy in Todelete)
				GameObject.Destroy(enemy);

			SceneManager.LoadScene ("Menu", LoadSceneMode.Single);

		}
			

		if (GUI.Button (new Rect (50, 190, 300, 50), "Quitter"))
			Application.Quit ();
		

	}
}
