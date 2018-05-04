using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public Transform SpawnPoint1;
	public Transform SpawnPoint2;
	public Transform SpawnPoint3;


	List<Vector3> Pos = new List<Vector3>{ new Vector3(-40f,1f, -1f),new Vector3(-30f,9f, -1f), new Vector3(-7f,20f, -1f), new Vector3(19f,20f, -1f), new Vector3(19f,25f, -1f), new Vector3(-20f,1f, -1f),new Vector3(20f,1f, -1f),new Vector3(36f,3f, -1f)};
	//private Vector3[] Pos = new[] { new Vector3(-40f,1f, -1f),new Vector3(-30f,9f, -1f), new Vector3(-7f,20f, -1f), new Vector3(19f,20f, -1f), new Vector3(19f,25f, -1f), new Vector3(-20f,1f, -1f),new Vector3(20f,1f, -1f),new Vector3(36f,3f, -1f)};


	private int random;


	// Use this for initialization
	void Start () {

	
		random = Random.Range (0, 7);
		Instantiate (SpawnPoint1, Pos[random], Quaternion.identity);
		Pos.RemoveAt( random );
		random = Random.Range (0, 6);
		Instantiate (SpawnPoint2, Pos[random], Quaternion.identity);
		Pos.RemoveAt( random );
		random = Random.Range (0,5);
		Instantiate (SpawnPoint3, Pos[random], Quaternion.identity);
		Pos.RemoveAt( random );

	}
	
	// Update is called once per frame

}
