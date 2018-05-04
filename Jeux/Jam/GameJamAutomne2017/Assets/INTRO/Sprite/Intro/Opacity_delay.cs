using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opacity_delay : MonoBehaviour {

	public float minimum = 0.0f;
	public float maximum = 1f;
	public float duration = 5.0f;
	public float delay = 5.0f;
	public float durationReplace = 5.0f;

	private float startTime;

	public SpriteRenderer spriteDown;

	public SpriteRenderer[] spriteSouvenirs;

	void Start() {
		startTime = Time.time;
		foreach(SpriteRenderer sprite in spriteSouvenirs)
			sprite.color = new Color(1f,1f,1f,0f);
	}

	void Update() {
		float t = (Time.time - startTime) / duration;

		spriteDown.color = new Color(1f,1f,1f,Mathf.SmoothStep(maximum, minimum, t));


		foreach(SpriteRenderer sprite in spriteSouvenirs)
			sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t));


	}
}
