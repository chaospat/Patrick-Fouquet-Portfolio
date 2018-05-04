using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour {

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}
}
