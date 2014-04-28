using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture menuBgr;
	private int menuWidth = 400;
	private int menuHeight = 400;
	private bool changingOptions;
	private bool inSettings;
	private bool inCredits;
	// Use this for initialization
	void Start () {
		changingOptions = false;
		inSettings = false;
		inCredits = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menuBgr);

		GUI.BeginGroup(new Rect((Screen.width - menuWidth)/2, (Screen.height - menuHeight)/2,menuWidth,menuHeight));

		if (!changingOptions)
		{
			if (GUI.Button(new Rect(150, 100, 100, 30), "NEW GAME"))
			{
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(150, 140, 100, 30), "Options"))
			{
				changingOptions = true;
				inSettings = true;
			}

			if (GUI.Button(new Rect(150, 180, 100, 30), "Credits"))
			{
				changingOptions = true;
				inCredits = true;
			}

			if (GUI.Button(new Rect(150, 220, 100, 30), "Quit"))
			{
				Application.Quit();
			}
		}
		else if (inSettings)
		{
			AudioListener.volume = GUI.HorizontalSlider(new Rect(150, 100, 100, 10), AudioListener.volume, 0.0f, 1.0f);
			if (GUI.Button(new Rect(150, 140, 100, 25), "Return"))
			{
				changingOptions = false;
				inSettings = false;
			}
		}
		else if (inCredits)
		{
			GUI.Label(new Rect(150, 100, 250, 100), "WYROBS BOGIEM");

			if (GUI.Button(new Rect(150, 210, 100, 25), "Return"))
			{
				changingOptions = false;
				inCredits= false;
			}

		}

		GUI.EndGroup();
	}
}
