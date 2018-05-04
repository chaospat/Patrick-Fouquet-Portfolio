using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsLancee : MonoBehaviour , Lancer{

	public string owner = "";

	public void Hit(PlayerController control, string name,GereObj player)
	{

	}


	public void HitWall()
	{
		Destroy (gameObject);

	}
}
