using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class counter : MonoBehaviour {

	public GameObject candyText;
	public float candySpeed = 1f;
	public GameObject candySpeedTextObject;
	private Text candySpeedText;
	public float candy = 0f;

	private void textCounter(){
		candyText.GetComponent<Text> ().text = ""+getCandyDisplayNum(candy);
		candy += candySpeed / 100;
	}

	private string getCandyDisplayNum(float candy)
	{
		float newCandy;
		string newCandyString;

		if (candy < 10000) {
			newCandy = Mathf.Round(candy);
			newCandyString = newCandy.ToString();
		} else if (candy > 9999 && candy < 1000000) {
			newCandy = Mathf.Round((candy / 1000)*10) / 10;
			newCandyString = newCandy.ToString()+" Thousand";

		} 
		else {
			newCandy = Mathf.Round(candy);
			newCandyString = newCandy.ToString();
		}
		return newCandyString;
	}


	// Use this for initialization
	void Start () {

		candySpeedText = candySpeedTextObject.GetComponent<Text> ();
		candySpeedText.text = Mathf.Round (candySpeed) + " Per Second ";
		InvokeRepeating("textCounter", 0.01f, 0.01f);
	
	}

	public void changeCandySpeed (float newSpeed){

		candySpeed = newSpeed * 1000f;
		candySpeedText.text = Mathf.Round (candySpeed) + " Per Second ";

	}
}
