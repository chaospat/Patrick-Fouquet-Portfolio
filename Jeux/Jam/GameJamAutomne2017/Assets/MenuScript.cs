using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {



	public InputField nameField;

	public static string charName;
	//private int active = 1;



	public void OnSubmit()
	{
		charName = nameField.text;

		SceneManager.LoadScene ("Intro", LoadSceneMode.Single);


	}


	public void Exit()
	{
		Application.Quit ();

	}

}
