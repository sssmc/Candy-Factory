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
		candyText.GetComponent<Text> ().text = "Candy Manufactured: " + Mathf.Round(candy);
		candy += candySpeed / 100;
	}


	// Use this for initialization
	void Start () {

		candySpeedText = candySpeedTextObject.GetComponent<Text> ();
		candySpeedText.text = "Candies per second: " + Mathf.Round (candySpeed);
		InvokeRepeating("textCounter", 0.01f, 0.01f);
	
	}

	public void changeCandySpeed (float newSpeed){

		candySpeed = newSpeed * 20f;
		candySpeedText.text = "Candies per second: " + Mathf.Round (candySpeed);

	}
}
