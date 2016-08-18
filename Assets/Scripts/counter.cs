using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class counter : MonoBehaviour {

	public GameObject candyText;
	public float candySpeed = 1f;
	public GameObject candySpeedTextObject;
	private Text candySpeedText;
	public float candy = 0f;
	public int ticksPerSecond;
	public float candyPrice;
	private money moneyScript;

	private void tick()
	{
		Debug.Log ("tick");
		candy += candySpeed / ticksPerSecond;
		candyText.GetComponent<Text> ().text = ""+getCandyDisplayNum(candy);
		candySpeedText.text = Mathf.Round (candySpeed) + " Per Second ";

		moneyScript.addMoney (candyPrice * (candySpeed / ticksPerSecond));
	}

	private string getCandyDisplayNum(float candy)
	{
		float newCandy;
		string newCandyString;

		if (candy < 10000) {
			newCandy = Mathf.Round(candy);
			newCandyString = newCandy.ToString()+"\nCandies";
		} 
		else if (candy >= 10000 && candy < 1000000) {
			newCandy = Mathf.Round((candy / 1000)*10) / 10;
			newCandyString = newCandy.ToString()+"\nThousand\nCandies";

		} 

		else if (candy >= 1000000 && candy < 1000000000) {
			newCandy = Mathf.Round((candy / 100000)*10) / 10;
			newCandyString = newCandy.ToString()+"\nMillion\nCandies";
			
		} 

		else {
			newCandy = Mathf.Round(candy);
			newCandyString = newCandy.ToString()+"\nCandies";
		}
		return newCandyString;
	}


	// Use this for initialization
	void Start () {

		moneyScript = GetComponent<money> ();

		candySpeedText = candySpeedTextObject.GetComponent<Text> ();
		InvokeRepeating("tick", 1.0f/ticksPerSecond, 1.0f/ticksPerSecond);
	
	}

	public void sliderChangeCandySpeed (float newSpeed){

		candySpeed = newSpeed;

	}
}
