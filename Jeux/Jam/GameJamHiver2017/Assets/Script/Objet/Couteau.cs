using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couteau : MonoBehaviour, Pickable {
	


	public string Pick()
	{
		Destroy (gameObject);
		return "Couteau";
	}


  
}
