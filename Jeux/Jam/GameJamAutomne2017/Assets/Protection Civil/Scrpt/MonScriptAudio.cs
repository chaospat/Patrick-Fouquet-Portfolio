using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MonScriptAudio : MonoBehaviour {

	public AudioClip[] audioClips;
	public int noCoup = 0;

	void OnEnable () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClips[noCoup];
		audio.Play ();

		noCoup++;
		if(noCoup == audioClips.Length)
			noCoup = 0;
	}
}
