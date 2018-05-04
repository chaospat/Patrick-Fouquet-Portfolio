using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed =5.0f;

	Animator animator;

	public static bool musee;

	void Start()
	{
		musee = true;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (musee == true) {
			animator.SetFloat ("Walk", 0);
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey ("a" )) {

				transform.localScale = new Vector3 (1, 1, 1);
				transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
				animator.SetFloat ("Walk", 2);
			}
			if (Input.GetKey (KeyCode.RightArrow)|| Input.GetKey ("d" )) {
				transform.localScale = new Vector3 (-1, 1, 1);
				transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
				animator.SetFloat ("Walk", 2);
			}
			if (Input.GetKey (KeyCode.UpArrow)|| Input.GetKey ("w" )) {
				transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
				animator.SetFloat ("Walk", 2);
			}
			if (Input.GetKey (KeyCode.DownArrow)|| Input.GetKey ("s" )) {
				transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
				animator.SetFloat ("Walk", 2);
			}

		} else {
			animator.SetFloat("Walk",0);
			
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{


		if (col.gameObject.tag == "LevelSpawnPoint") {

			musee = false;

		}
	}



}
