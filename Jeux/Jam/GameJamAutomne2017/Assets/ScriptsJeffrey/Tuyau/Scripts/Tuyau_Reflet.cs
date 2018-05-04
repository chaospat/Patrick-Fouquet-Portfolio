using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyau_Reflet : MonoBehaviour {

	public GameObject laserUnique;
	public Transform laserSpawn;

	void OnTriggerEnter2D(Collider2D other){
			Destroy (other.gameObject);
			Instantiate (laserUnique, laserSpawn.position, laserSpawn.rotation);
		}
}
