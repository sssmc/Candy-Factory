using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class factories : MonoBehaviour {

	List<Factory> Factories = new List<Factory>();
	List<GameObject> factoryButtons = new List<GameObject> ();
	public int currentFactory = 0;
	public GameObject factoryNameTextObject;
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

		factoryNameTextObject.GetComponent<Text> ().text = Factories [currentFactory].getName ();

	}

	public void addFactory(string name, int index)
	{
		Factories.Add(new Factory(name,factoryButtons[0], canvas, factoryPanelPrefab));
		Factories [index].panel = Instantiate (factoryPanelPrefab);
		Factories [index].panel.transform.parent = canvas.transform;
		Factories [index].panel.GetComponent<RectTransform> ().localPosition = new Vector2(0,-47);
		Factories [index].panel.GetComponent<RectTransform>().sizeDelta = new Vector2(549,388);
		Factories [index].activate ();
		factoryButtons.RemoveAt (0);
		setCurrentFactory (index);
	}

	public void setCurrentFactory (int index)
	{
		Factories [currentFactory].deactivate ();
		currentFactory = index;
		Factories [currentFactory].activate ();
		factoryNameTextObject.GetComponent<Text> ().text = Factories [currentFactory].getName ();
	}
}

public class Factory{

	private string name;
	private GameObject button;
	public GameObject panel;
	public Factory(string newName, GameObject newButton, GameObject canvas, GameObject factoryPanelPrefab)
	{
		name = newName;
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
