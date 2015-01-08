using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	private string tagInstructions = "Instructions";
	private GameObject instructions;

	// Use this for initialization
	void Start ()
	{
		instructions = GameObject.FindGameObjectWithTag (tagInstructions);
		instructions.active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel - 1);
	}

	public void QuitToMainMenu()
	{
		Application.LoadLevel(0);
	}

	public void ShowInstructions()
	{
		instructions.active = true;
	}

	public void CloseInstructions()
	{
		instructions.active = false;
	}
}
