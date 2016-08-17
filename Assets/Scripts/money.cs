using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class money : MonoBehaviour {
	public float Money = 100f;
	public GameObject moneyTextGameboject;
	private Text moneyText;
	// Use this for initialization
	void Start () {
		moneyText = moneyTextGameboject.GetComponent<Text> ();
		moneyText.text = ""+Money;
	}

	public void addMoney(float toAdd)
	{
		Money += toAdd;
		moneyText.text = ""+Mathf.Round(Money * 10)/10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
