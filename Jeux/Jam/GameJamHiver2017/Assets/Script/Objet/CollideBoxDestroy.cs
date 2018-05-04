using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBoxDestroy : MonoBehaviour {


	// Use this for initialization

	public void DesactiveCollideBox(){
		foreach (TossWhenHit T in GetComponentsInChildren<TossWhenHit>()) {
			T.mesBoules = false;
		}
			
	}
}
