using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	
	public GameObject mob;
	private GameController gameController;
	Vector3 pos;
	
	public int hazardCountMin;
	public int hazardCountMax;
	private int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	
	private int waveNumber = 0;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameControllerCivil");
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		else if (gameController == null){
			Debug.Log ("Cannot find 'GameControllerCivil' script");
		}

		pos = gameObject.transform.position;
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves()
	{
		
		yield return new WaitForSeconds (startWait);
		//PARTIE 2 : VAGUE D'Ennemi
		while(!gameController.gameOver)
			{
			hazardCount = Random.Range (hazardCountMin, hazardCountMax);
			for(int i = hazardCount + waveNumber*2; i>0; i--){
		
				Vector3 spawnPosition = new Vector3 (pos.x,  Random.Range(pos.y -1, pos.y +1), pos.z-1);
				Instantiate (mob, spawnPosition, Quaternion.identity);
		
				yield return new WaitForSeconds (spawnWait);
				}
			waveNumber++;

			//
			yield return new WaitForSeconds (waveWait);

			if (waveNumber >= gameController.nbWave)
				gameController.GameOver ();
			}
		}
	}