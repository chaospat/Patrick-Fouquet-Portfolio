using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyau_Normal : MonoBehaviour {

	public AudioClip audioSong;
	private AudioSource song;

	void Start(){	
		song = GetComponentInParent<AudioSource>  ();
		song.clip = audioSong;
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
		song.Play ();


		}
	void OnTriggerStay2D(Collider2D other){
		Destroy (other.gameObject);
		song.Play ();
	}

}
