using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuessSliderBehavior : MonoBehaviour {

	Slider slider;
	Text chosenText;

	// Use this for initialization
	void Start () {

		//Find the Slider
		GameObject sliderGameObject = GameObject.Find ("GuessSlider");
		slider = sliderGameObject.GetComponent<Slider> ();

		if (slider == null) {
			Debug.LogError("GuessSliderBehavior is not attached to a slider");
		}

		//Add event handler to slider
		slider.onValueChanged.AddListener (OnValueChanged);

		//Find the Text
		GameObject textGameObject = GameObject.Find ("ChosenNumberText");
		chosenText = textGameObject.GetComponent<Text> ();

		if (chosenText == null) {
			Debug.LogError("GuessSliderBehavior is not attached to an Output text");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnValueChanged(float value){
		//Debug.Log ("OnDrag Event - Value " + slider.value);
		chosenText.text = value.ToString ();
	}

}
