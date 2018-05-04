using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Move_time : MonoBehaviour {

	float t;
	Vector3 startPosition;
	public Vector3 target;
	public float timeToReachTarget;

	void Start()
	{
		startPosition = transform.position;
	}
	void Update() 
	{
		t += Time.deltaTime/timeToReachTarget;
		transform.position = Vector3.Lerp(startPosition, target, t);
	}
	/*
	public void SetDestination(Vector3 destination, float time)
	{
		t = 0;
		startPosition = transform.position;
		timeToReachTarget = time;
		target = destination; 
	}*/
}
