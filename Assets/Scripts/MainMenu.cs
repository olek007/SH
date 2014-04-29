using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture menuBgr;
	private int menuWidth;
	private int menuHeight;
	private int buttonWidth;
	private int buttonHeigh;
	private bool changingOptions;
	private bool inSettings;
	private bool inCredits;

	void Start () 
	{
		changingOptions = false;
		inSettings = false;
		inCredits = false;
		buttonWidth = 200;
		buttonHeigh = 60;
		menuWidth = 400;
		menuHeight = (buttonHeigh + 10) * 4;
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menuBgr);

		GUI.BeginGroup(new Rect((Screen.width - menuWidth)/2, (Screen.height - menuHeight)/2,menuWidth,menuHeight));

		if (!changingOptions)
		{
			if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, 0, buttonWidth, buttonHeigh), "NEW GAME"))
			{
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, buttonHeigh + 10, buttonWidth, buttonHeigh), "Options"))
			{
				changingOptions = true;
				inSettings = true;
			}

			if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, (buttonHeigh + 10) * 2, buttonWidth, buttonHeigh), "Credits"))
			{
				changingOptions = true;
				inCredits = true;
			}

			if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, (buttonHeigh + 10) * 3, buttonWidth, buttonHeigh), "Quit"))
			{
				Application.Quit();
			}
		}
		else if (inSettings)
		{
			AudioListener.volume = GUI.HorizontalSlider(new Rect((menuWidth - buttonWidth) / 2, 100, buttonWidth, buttonHeigh / 3), AudioListener.volume, 0.0f, 1.0f);
			if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, buttonHeigh + 100, buttonWidth, buttonHeigh), "Return"))
			{
				changingOptions = false;
				inSettings = false;
			}
		}
		else if (inCredits)
		{
			GUI.Label(new Rect((menuWidth - buttonWidth) / 2, 100, buttonWidth, 100), "WYROBS BOGIEM");

			if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, 210, buttonWidth, buttonHeigh), "Return"))
			{
				changingOptions = false;
				inCredits= false;
			}

		}

		GUI.EndGroup();
	}
}
