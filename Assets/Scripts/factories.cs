using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class factories : MonoBehaviour {

	public List<Factory> Factories = new List<Factory>();
	List<GameObject> factoryButtons = new List<GameObject> ();
	public int currentFactory = 0;
	public GameObject factoryNameTextObject;
	public GameObject factorySpeedTextObject;
	public GameObject factoryCandyMadeTextObject;
	public GameObject factroyButtonPrefab;
	public GameObject factoriesPanel;
	public GameObject canvas;
	public GameObject factoryPanelPrefab;

	// Use this for initialization
	void Start () {

		foreach (Transform child in factoriesPanel.transform) 
		{
			factoryButtons.Add(child.gameObject);
		}

		addFactory ("default", 0);
		addFactory ("new Factory", 1);

		updateFactory (currentFactory);

	}

	public void addFactory(string name, int index)
	{
		Factories.Add(new Factory(name,factoryButtons[0], canvas, factoryPanelPrefab));
		Factories [index].panel = Instantiate (factoryPanelPrefab);
		Factories [index].panel.transform.parent = canvas.transform;
		Factories [index].panel.GetComponent<RectTransform> ().localPosition = new Vector2(0,0);
		Factories [index].panel.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
		Factories [index].panel.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		Factories [index].activate ();
		factoryButtons.RemoveAt (0);
		setCurrentFactory (index);
	}

	public void setCurrentFactory (int index)
	{
		Factories [currentFactory].deactivate ();
		currentFactory = index;
		Factories [currentFactory].activate ();
		updateFactory(currentFactory);
	}
	public void updateFactory(int index)
	{
		factoryNameTextObject.GetComponent<Text> ().text = Factories [index].getName ();
		factorySpeedTextObject.GetComponent<Text> ().text = Mathf.Round(Factories [index].candySpeed)+" Candy Per Second";
		factoryCandyMadeTextObject.GetComponent<Text> ().text = Mathf.Round(Factories [index].candyMade)+" Candies Made";
	}
}

public class Factory{

	private string name;
	private GameObject button;
	public GameObject panel;
	public float candySpeed;
	public float moneySpeed;
	public float moneyMade;
	public float candyMade;
	public Factory(string newName, GameObject newButton, GameObject canvas, GameObject factoryPanelPrefab)
	{
		name = newName;
		candySpeed = 1f;
		moneySpeed = 1f;
		button = newButton;
		button.transform.GetChild (0).GetComponent<Text> ().text = name;
		button.GetComponent<Button> ().interactable = true;
	}
	public void activate()
	{
		button.transform.GetChild (0).GetComponent<Text> ().color = Color.black;
		panel.SetActive(true);
	}
	public void deactivate()
	{
		panel.SetActive (false);
	}

	public string getName()
	{
		return name;
	}

}
