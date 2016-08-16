using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class counter : MonoBehaviour {

	public GameObject candyText;
	private int candy = 0;

	private void textCounter(){
		candyText.GetComponent<Text> ().text = "Candy Manufactured: " + candy;
		candy ++;
	}


	// Use this for initialization
	void Start () {

		InvokeRepeating("textCounter", 1, 1);
	
	}
}
