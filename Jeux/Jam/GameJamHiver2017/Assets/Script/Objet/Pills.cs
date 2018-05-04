using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour, Pickable {

	public string Pick()
	{
		Destroy (gameObject);
		return "Pills";
	}

}
