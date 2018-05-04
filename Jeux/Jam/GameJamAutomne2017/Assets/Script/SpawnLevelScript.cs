using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLevelScript : MonoBehaviour {

	public string level;
	public Vector3 position;
	private bool done = false;
	private SpriteRenderer sprite;



	void OnTriggerEnter2D(Collider2D col)
	{
		if (done == false) {


			if (col.gameObject.tag == "DontDestroyOnLoad") {


				transform.position = position;


				SceneManager.LoadScene (level, LoadSceneMode.Single);
				done = true;

				GameObject[] ToHide = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
				foreach (GameObject obj in ToHide) {

					obj.transform.Translate (0, 0, 10);




				}

				GetComponent<BoxCollider2D> ().enabled = false;
				GetComponent<CircleCollider2D> ().enabled = false;

			}

		}

	}
	// Use this for initialization

}
