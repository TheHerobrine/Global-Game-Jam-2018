using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public GameObject newGame;
	public GameObject options;
	public GameObject credits;
	public GameObject quit;

	public int currentSelection = 0;

	// Use this for initialization
	void Start ()
	{
		SelectText(newGame);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("down"))
		{
			UnselectText(GetElement(currentSelection));
			currentSelection++;
			currentSelection %= 4;
			SelectText(GetElement(currentSelection));
		}
		if (Input.GetKeyDown("up"))
		{
			UnselectText(GetElement(currentSelection));
			currentSelection += 3;
			currentSelection %= 4;
			SelectText(GetElement(currentSelection));
		}

		if (Input.GetKeyDown("return"))
		{
			switch (currentSelection)
			{
				case 0:
					SceneManager.LoadScene("gameIntro");
					break;
				case 3:
					Application.Quit();
					break;
			}
		}
	}

	GameObject GetElement(int selection)
	{
		switch (selection)
		{
			case 1:
				return this.options;
				break;
			case 2:
				return this.credits;
				break;
			case 3:
				return this.quit;
				break;
			default:
				return this.newGame;
				break;
		}
	}

	void SelectText(GameObject element)
	{
		TextMeshProUGUI textElement = element.GetComponent<TextMeshProUGUI>();
		textElement.text = "( " + textElement.text + " )";
	}

	void UnselectText(GameObject element)
	{
		TextMeshProUGUI textElement = element.GetComponent<TextMeshProUGUI>();
		textElement.text = textElement.text.Substring(2, textElement.text.Length - 4);
	}
}
