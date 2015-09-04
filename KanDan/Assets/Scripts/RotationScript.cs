using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public float angularSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, new Vector3 (0, 0, -1), Time.deltaTime * angularSpeed);	
	}
}
