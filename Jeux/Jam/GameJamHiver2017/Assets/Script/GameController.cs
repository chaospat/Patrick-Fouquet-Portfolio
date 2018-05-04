using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public GameObject[] hazardsMurs;

	private GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	GameManager gameManager;

	public float speedFall;

    void Start()
    {
		gameManager = GameObject.Find ("GameController").GetComponent<GameManager> ();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);
		while (true) {
		if (gameManager.gameState == GameManager.State.Playing) {
				
				Vector3 spawnPosition;
				hazard = hazardsMurs[Random.Range (0, hazardsMurs.Length)];
				spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);

				Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);

				GameObject obj = (GameObject)Instantiate (hazard, spawnPosition, spawnRotation);
				obj.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, speedFall);

				yield return new WaitForSeconds (2);

				for (int i = 0; i < hazardCount; i++) {

					hazard = hazards[Random.Range (0, hazards.Length)];
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 0, 0);

					obj = (GameObject)Instantiate (hazard, spawnPosition, spawnRotation);
					obj.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, speedFall);

					yield return new WaitForSeconds (spawnWait);
				}
				yield return new WaitForSeconds (waveWait);
			}else{
				yield return new WaitForSeconds(1);
			}
		}
    }
}