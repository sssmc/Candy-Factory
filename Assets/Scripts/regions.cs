using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class regions : MonoBehaviour {

	public List<Region> Regions = new List<Region>();
	List<GameObject> regionButtons = new List<GameObject> ();
	public int currentRegion = 0;
	public GameObject regionNameTextObject;
	public GameObject regionSpeedTextObject;
	public GameObject regionCandyMadeTextObject;
	public GameObject factroyButtonPrefab;
	public GameObject regionsPanel;
	public GameObject canvas;
	public GameObject regionPanelPrefab;

	// Use this for initialization
	void Start () {

		foreach (Transform child in regionsPanel.transform) 
		{
			regionButtons.Add(child.gameObject);
		}

		addRegion ("default", 0);
		addRegion ("new Region", 1);

		updateRegion (currentRegion);

	}

	public void addRegion(string name, int index)
	{
		Regions.Add(new Region(name,regionButtons[0], canvas, regionPanelPrefab));
		Regions [index].panel = Instantiate (regionPanelPrefab);
		Regions [index].panel.transform.parent = canvas.transform;
		Regions [index].panel.GetComponent<RectTransform> ().localPosition = new Vector2(0,0);
		Regions [index].panel.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
		Regions [index].panel.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		Regions [index].activate ();
		regionButtons.RemoveAt (0);
		setCurrentRegion (index);
	}

	public void setCurrentRegion (int index)
	{
		Regions [currentRegion].deactivate ();
		currentRegion = index;
		Regions [currentRegion].activate ();
		updateRegion(currentRegion);
	}
	public void updateRegion(int index)
	{
		regionNameTextObject.GetComponent<Text> ().text = Regions [index].getName ();
		regionSpeedTextObject.GetComponent<Text> ().text = Mathf.Round(Regions [index].candySpeed)+" Candy Per Second";
		regionCandyMadeTextObject.GetComponent<Text> ().text = Mathf.Round(Regions [index].candyMade)+" Candies Made";
	}
}

public class Region{

	private string name;
	private GameObject button;
	public GameObject panel;
	public float candySpeed;
	public float moneySpeed;
	public float moneyMade;
	public float candyMade;
	public Region(string newName, GameObject newButton, GameObject canvas, GameObject regionPanelPrefab)
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
