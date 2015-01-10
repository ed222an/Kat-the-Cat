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
		instructions.SetActive(false);
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

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ShowInstructions()
	{
		instructions.SetActive(true);
	}

	public void CloseInstructions()
	{
		instructions.SetActive(false);
	}
}
