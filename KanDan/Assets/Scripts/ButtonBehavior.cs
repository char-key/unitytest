using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

	AudioClip test;
	AudioSource buttonAudio;

	// Use this for initialization
	void Start () {
		test = Resources.Load ("record_1") as AudioClip;	
		buttonAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		Debug.Log ("buttonAudio.isPlaying = " + buttonAudio.isPlaying);

		if ( !buttonAudio.isPlaying ) {
			buttonAudio.PlayOneShot (test);
		}
	}
}
