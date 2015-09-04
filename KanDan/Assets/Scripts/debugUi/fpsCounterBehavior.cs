using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fpsCounterBehavior : MonoBehaviour {

	float fps; 
	Text fpsOutput;

	// Use this for initialization
	void Start () {
		fpsOutput = GetComponent<Text>();

		if( fpsOutput == null){
			Debug.LogError("Unable to print fps output");
			return;
		}

		StartCoroutine(CalculateFps());
	}

	IEnumerator CalculateFps(){
		while(true){
			fps = 1/Time.deltaTime;
			yield return new WaitForSeconds(1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		fpsOutput.text = "FPS : " + string.Format("{0:0.00}", fps);
	}
}
