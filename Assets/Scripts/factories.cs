using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class factories : MonoBehaviour {

	List<Factory> Factories = new List<Factory>();
	public int currentFactory = 0;
	public GameObject factoryNameTextObject;
	public GameObject factroyButtonPrefab;
	public GameObject factoriesPanel;
	public GameObject factoryButton;

	// Use this for initialization
	void Start () {
		Factories.Add(new Factory("Default"));
		factoryNameTextObject.GetComponent<Text> ().text = Factories [currentFactory].getName ();

		factoryButton = Instantiate (factroyButtonPrefab);
		factoryButton.transform.parent = factoriesPanel.transform;
		factoryButton.GetComponent<RectTransform> ().position = new Vector2 (0, 464);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Factory {

	private string name;
	public Factory(string newName)
	{
		name = newName;
	}
	public string getName()
	{
		return name;
	}

}
