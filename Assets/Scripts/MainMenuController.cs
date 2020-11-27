using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	void Awake()
	{
		//TODO initialize gamemanager
	}

	public void HandleOnStateChange()
	{
		Debug.Log("OnStateChange mainmenu!");
	}

	public void LevelSelect()
	{
		//TODO is for level select stuff
	}

	public void StartGame()
	{
		//TODO go to first or next level
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
