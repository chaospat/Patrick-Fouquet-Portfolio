using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilMove : MonoBehaviour {

	// Update is called once per frame
	private bool up = true;
	void FixedUpdate () {

		Vector3 newPos = transform.position;

		if (transform.position.y >= -2.0)
			up = false;
		if (transform.position.y <= -3.0)
			up = true;
		
		if (up)
			newPos.y += 0.05f;
		else
			newPos.y -= 0.05f;

		transform.position = newPos;
	}
}
