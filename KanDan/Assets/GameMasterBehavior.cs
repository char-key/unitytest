using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMasterBehavior : MonoBehaviour {

	Text chosenText, lowerText, upperText;
	Button guessButton;
	Slider slider;

	MakeNumber gameLogic;

	// Use this for initialization
	void Start () {

		gameLogic = new MakeNumber ();

		//Find the Text
		GameObject textGameObject = GameObject.Find ("ChosenNumberText");
		chosenText = textGameObject.GetComponent<Text> ();
		
		if (chosenText == null) {
			Debug.LogError("GameMasterBehavior is not attached to an Output text");
		}

		//Find the lowerLimit Text
		GameObject lowerTextGameObject = GameObject.Find ("LowerNumberText");
		lowerText = lowerTextGameObject.GetComponent<Text> ();
		
		if (lowerText == null) {
			Debug.LogError("GameMasterBehavior is not attached to an Output text");
		}

		//Find the upperLimit Text
		GameObject upperTextGameObject = GameObject.Find ("UpperNumberText");
		upperText = upperTextGameObject.GetComponent<Text> ();
		
		if (upperText == null) {
			Debug.LogError("GameMasterBehavior is not attached to an Output text");
		}

		//Find the Button
		GameObject buttonGameObject = GameObject.Find ("GuessButton");
		guessButton = buttonGameObject.GetComponent<Button> ();
		
		if (guessButton == null) {
			Debug.LogError("GameMasterBehavior is not attached to a button");
		}

		//Add the event handler
		guessButton.onClick.AddListener (guessAction);

		//Find the Slider
		GameObject sliderGameObject = GameObject.Find ("GuessSlider");
		slider = sliderGameObject.GetComponent<Slider> ();
		
		if (slider == null) {
			Debug.LogError("GameMasterBehavior is not attached to a slider");
		}

		gameInitialize ();
	}

	void gameInitialize(){
		int lowerBound, upperBound;
		
		lowerBound = gameLogic.Range_min;
		upperBound = gameLogic.Range_max;
		
		Debug.Log("Lower: " + lowerBound + ", Upper: " + upperBound);

		int firstChosen  = (lowerBound + upperBound) / 2; 
		chosenText.text = firstChosen.ToString ();
		
		slider.minValue = lowerBound;
		slider.maxValue = upperBound;
		
		lowerText.text = lowerBound.ToString();
		upperText.text = upperBound.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void guessAction(){

		//TODO: Secure this line of code
		int numberChosen = int.Parse (chosenText.text);
		Debug.Log ("Number Guessed: " + numberChosen);


		int result = gameLogic.Guess (numberChosen);
		Debug.Log ("result = " + result);

		if (result == 0) {
			//TODO: Win Screen
			Debug.Log("You Win!");
		} else {
			//Continue the game
			int lowerBound, upperBound;

			lowerBound = gameLogic.Range_min;
			upperBound = gameLogic.Range_max;

			Debug.Log("Lower: " + lowerBound + ", Upper: " + upperBound);

			slider.minValue = lowerBound;
			slider.maxValue = upperBound;

			lowerText.text = lowerBound.ToString();
			upperText.text = upperBound.ToString();
		}
	}
}
