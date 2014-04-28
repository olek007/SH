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


	// Use this for initialization
	void Start () {
		changingSettings = false;
		selectingLvl = false;
		optionsActive = false;
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(pause = GUI.Toggle(new Rect(Screen.width-90,Screen.height-90, 80,80),pause,currentPausePlayTxt,"button"))
		{
			Time.timeScale = 0.0000000001f;
			currentPausePlayTxt = pausePlayTxt[0];
			SpellsGUI.isGUIDisabled = true;

			GUI.BeginGroup(new Rect(Screen.width/2 - 50, Screen.height/2 -25, 100, 200));

			if(!optionsActive)
			{
				if(GUI.Button(new Rect(0,0,100,25),"QUIT"))
				{
					Application.LoadLevel(0);
				}
			

				 if(GUI.Button(new Rect(0,30,100,25),"Options"))
				{
					optionsActive = true;
					changingSettings= true;

				}

				if(GUI.Button(new Rect(0,60,100,25),"Lvl Select"))
				{
					optionsActive = true;
					selectingLvl = true;
				}
			}
			else if(changingSettings)
			{
				AudioListener.volume = GUI.HorizontalSlider(new Rect(0,25, 100,10),AudioListener.volume,0.0f,1.0f);
				if(GUI.Button(new Rect(0,40,100,25),"Return"))
				{
					optionsActive = false;
					changingSettings = false;
				}
			}
			else if(selectingLvl)
			{
				if(GUI.Button(new Rect(0,0,100,25),"Lvl1"))
				{
					Application.LoadLevel(1);
				}
				else if(GUI.Button(new Rect(0,40,100,25),"Return"))
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
