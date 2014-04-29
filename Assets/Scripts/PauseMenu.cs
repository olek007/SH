using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public Texture [] pausePlayTxt;  // 0- pause  1- play
	private Texture currentPausePlayTxt;
	private bool optionsActive;
	private bool selectingLvl;
	private bool changingSettings; 
	private bool pause;
	private int levelSelected;
	private int buttonWidth;
	private int buttonHeigh;
	private int menuWidth;
	private int menuHeight;

	void Start ()
	{
		changingSettings = false;
		selectingLvl = false;
		optionsActive = false;
		pause = false;
		buttonWidth = 200;
		buttonHeigh = 60;
		menuWidth = 400;
		menuHeight = (buttonHeigh + 10) * 3;
	}
	


	void OnGUI()
	{
		if(pause = GUI.Toggle(new Rect(Screen.width-90,Screen.height-90, 80,80),pause,currentPausePlayTxt,"button"))
		{
			Time.timeScale = 0.0000000001f;
			currentPausePlayTxt = pausePlayTxt[0];
			SpellsGUI.isGUIDisabled = true;

			GUI.BeginGroup(new Rect((Screen.width - menuWidth) / 2, (Screen.height - menuHeight) / 2, menuWidth, menuHeight));

			if(!optionsActive)
			{
				if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, 0, buttonWidth, buttonHeigh), "QUIT"))
				{
					Application.LoadLevel(0);
				}


				if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, buttonHeigh + 10, buttonWidth, buttonHeigh), "Options"))
				{
					optionsActive = true;
					changingSettings= true;

				}

				if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, (buttonHeigh + 10) * 2, buttonWidth, buttonHeigh), "Lvl Select"))
				{
					optionsActive = true;
					selectingLvl = true;
				}
			}
			else if(changingSettings)
			{
				AudioListener.volume = GUI.HorizontalSlider(new Rect((menuWidth - buttonWidth) / 2, 0, buttonWidth, buttonHeigh / 3), AudioListener.volume, 0.0f, 1.0f);
				if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, buttonHeigh + 10, buttonWidth, buttonHeigh), "Return"))
				{
					optionsActive = false;
					changingSettings = false;
				}
			}
			else if(selectingLvl)
			{
				if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, 0, buttonWidth, buttonHeigh), "Lvl1"))
				{
					Application.LoadLevel(1);
				}
				else if (GUI.Button(new Rect((menuWidth - buttonWidth) / 2, buttonHeigh + 10, buttonWidth, buttonHeigh), "Return"))
				{
					optionsActive = false;
					selectingLvl = false;
				}

			}
		

			GUI.EndGroup();


		}
		else
		{
			if(!SpellsGUI.failed)
			{
				Time.timeScale = 1.0f;
			}
			currentPausePlayTxt = pausePlayTxt[1];
			SpellsGUI.isGUIDisabled = false;
		}



	
	}
}
