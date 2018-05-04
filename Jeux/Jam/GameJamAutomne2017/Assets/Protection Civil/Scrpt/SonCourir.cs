using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SonCourir : MonoBehaviour {
	public AudioClip audioClips;
	// Use this for initialization
	void OnEnable () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClips;

		audio.Play();
	}
}
