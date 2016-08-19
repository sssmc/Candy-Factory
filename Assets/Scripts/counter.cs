using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class counter : MonoBehaviour {

	public GameObject candyText;
	public float candySpeed = 1f;
	public float moneySpeed = 1f;
	public GameObject candySpeedTextObject;
	private Text candySpeedText;
	public float candy = 0f;
	public int ticksPerSecond;
	public float candyPrice;
	private money moneyScript;
	private factories factoriesScript;

	private void tick()
	{
		candySpeed = getSpeed ().x;
		moneySpeed = getSpeed ().y;
		candy += candySpeed;
		candyText.GetComponent<Text> ().text = ""+getCandyDisplayNum(candy);
		candySpeedText.text = Mathf.Round (candySpeed * ticksPerSecond) + " Per Second ";

		moneyScript.addMoney (moneySpeed);

		factoriesScript.updateFactory (factoriesScript.currentFactory);

	}

	private Vector2 getSpeed()
	{
		float totalCandySpeed = 0;
		float totalMoneySpeed = 0;
		foreach (Factory factory in GetComponent<factories>().Factories) 
		{
			totalCandySpeed += factory.candySpeed;
			totalMoneySpeed += factory.moneySpeed;
			factory.candyMade += (factory.candySpeed / ticksPerSecond)/2;
			factory.moneyMade += (factory.moneySpeed / ticksPerSecond)/2;
		}
		return new Vector2(totalCandySpeed/ ticksPerSecond,totalMoneySpeed / ticksPerSecond);
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
		factoriesScript = GetComponent<factories> ();

		candySpeedText = candySpeedTextObject.GetComponent<Text> ();
		InvokeRepeating("tick", 1.0f/ticksPerSecond, 1.0f/ticksPerSecond);
	
	}

	public void sliderChangeCandySpeed (float newSpeed){

		candySpeed = newSpeed;

	}
}
