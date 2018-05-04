using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour {
    public float Upvalue = 0.25f;
	public float Downvalue = 1;
    public float timeBetweenUp = 1;
    public float smoothValue = 0.15f;
	public float maximumY = -0.05f;
    //public float speed = 2f;
	public GameObject explosion;
    float timeRemaining;
    Vector3 targetPos;

	public AudioSource audioPolice;

	GameManager gameManager;
	void Start () {
        timeRemaining = timeBetweenUp;
        //StartCoroutine("move");
        targetPos = Vector3.zero;
		gameManager = GameObject.Find ("GameController")
			.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.gameState == GameManager.State.Playing) {
			timeRemaining -= Time.deltaTime;
			if (timeRemaining < 0) {
				if (transform.position.y + Upvalue <= maximumY) {
					
					targetPos = new Vector3 (transform.position.x, transform.position.y + Upvalue, transform.position.z);
					timeRemaining = timeBetweenUp; 
				} else {
					targetPos = new Vector3 (transform.position.x, maximumY, transform.position.z);

				}

			}

			if (targetPos != Vector3.zero) {
				
				transform.position = Vector3.Lerp (transform.position, targetPos, smoothValue);
				if (Vector3.Distance (transform.position, targetPos) < 0.1) {
					foreach (Animator t in GetComponentsInChildren<Animator>()) {
						t.SetFloat ("VerticalSpeed", 0);
					}
					targetPos = Vector3.zero;


				} else {
					foreach (Animator t in GetComponentsInChildren<Animator>()) {
						t.SetFloat ("VerticalSpeed", 1);

					}
				}
			}
		}
	}
	void OnCollisionEnter2D (Collision2D collider)  {
		
	}
	void OnTriggerEnter2D (Collider2D collider)  {
		if (collider.gameObject.tag == "Player1") {
			gameManager.gameState = GameManager.State.WinPlayer2;
			Time.timeScale = 0;
		} else if (collider.gameObject.tag == "Player2") {
			gameManager.gameState = GameManager.State.WinPlayer1;
			Time.timeScale = 0;
		}
		if (collider.gameObject.tag == "OsLancee") {
			targetPos = new Vector3 (transform.position.x, transform.position.y - Downvalue, transform.position.z);
			timeRemaining = timeBetweenUp;
		}
		if (collider.gameObject.tag == "Mur") {

			Debug.Log ("Creating Explosiion");
			if (explosion != null) {
				Vector3 newPos = collider.gameObject.transform.position;
				newPos.x = -6.6f;
				Instantiate (explosion, newPos, Quaternion.identity);

			}
			Destroy (collider.gameObject);
		}
		if (collider.tag == "OsLancee")
			audioPolice.Play ();

		if (collider.tag != "Bg") {
			Destroy (collider.gameObject);
		}
	}

    /*IEnumerator move()
    {
        while (true) // Condition to check if game is finished
        {
            yield return new WaitForSeconds(timeBetweenUp);
            transform.Translate(new Vector3(0, Upvalue, 0));
        }
    } */
}
