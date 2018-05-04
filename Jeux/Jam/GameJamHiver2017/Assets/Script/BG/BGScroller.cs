using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour 
{

	public float scrollSpeed;
	public float tileSizeY;
	GameManager gameManager;
	private Vector3 startPosition;

	void Start () 
	{
		gameManager = GameObject.Find ("GameController").GetComponent<GameManager> ();
			startPosition = transform.position;
	}

	void Update ()
	{
		if (gameManager.gameState == GameManager.State.Playing) {
			float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);
			transform.position = startPosition + Vector3.up * newPosition;
		}
	}
}