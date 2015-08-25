using UnityEngine;
using System.Collections;

public class WinnerSpriteBehavior : MonoBehaviour {

	float startTime;

	// Use this for initialization
	void Start () {
		//Play the sound when the sprite loads
		GetComponent<AudioSource>().PlayOneShot( Resources.Load ("woosh8") as AudioClip );	

		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time - startTime > 5 ){
			Application.LoadLevel("MainGame");
		}	
	}
}
