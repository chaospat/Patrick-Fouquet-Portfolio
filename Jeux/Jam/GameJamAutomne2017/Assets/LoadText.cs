using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;



public class LoadText : MonoBehaviour {

	//TextAsset text = Resources.Load(@"Score\Score.txt\") as TextAsset;
	//private string file_path = @"Score\Score.txt";
	//public string txtFile = "Score";
	//string txtContents;


	public Text  scoreText;
	private string txtTemp;


	// Use this for initialization
	void Start () {


		string[] lines = System.IO.File.ReadAllLines(@"Score\Score.txt");
		//TextAsset txtAssests = (TextAsset)Resources.Load (txtFile);
		//txtContents = txtAssests.text;

		for (int i = 0; i < lines.Length; i++) {
			txtTemp = lines[i] + Environment.NewLine ;
			scoreText.text = txtTemp + scoreText.text;

		}

		
	}


	// Update is called once per frame
	//void OnGUI () {
	//	GUILayout.Label (txtContents);
	//}
}
