using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Os : MonoBehaviour,Pickable  {

	public string Pick()
	{
		Destroy (gameObject);
		return "Os";
	}

}
