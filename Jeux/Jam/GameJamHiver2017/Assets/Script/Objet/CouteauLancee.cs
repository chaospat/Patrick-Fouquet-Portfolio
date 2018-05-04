using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouteauLancee : MonoBehaviour , Lancer{
	public float temps = 2;
	public GameObject effect;
	public string owner = "";

	public void Hit(PlayerController control, string name,GereObj player)
	{
		if (name != owner) {
			control.ralentissement (temps, name);
			if (name == "Player1") {
				GameObject.Find ("PanneauP1").GetComponent<PlayerUI> ().setEffect("vitesseDOWN");
			} else if (name == "Player2") {
				GameObject.Find ("PanneauP2").GetComponent<PlayerUI> ().setEffect ("vitesseDOWN");

			}
			player.audioCouteau.Play ();
			if (effect != null) {
				GameObject obj = Instantiate (effect, GameObject.Find (name).transform.position,Quaternion.identity);
				obj.transform.parent = GameObject.Find (name).transform;
			}
			Destroy (gameObject);
		}
	}

}
