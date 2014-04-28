using UnityEngine;
using System.Collections;

public class SpellsGUI : MonoBehaviour {
	
	private Vector2 scrollPosition1 = Vector2.zero;
    private Vector2 scrollPosition2 = Vector2.zero;
    private Vector2 scrollPosition3 = Vector2.zero;
	public Texture [] button_czerwony;
	public Texture [] button_niebieski;
	public Texture [] button_zielony;
	public Texture [] spellToggleTxt;
	public Texture cancelTex;
	public Texture TimeBackground;
	public Texture TimeForeground;
	public Texture ManaBackground;
	public Texture ManaForeground;
	public static int currentSpell1;
	public static int currentSpell2;
	public static int currentSpell3;
	private int currentTg;
	private bool cancelSpell;
	public static bool failed;
	public static bool isGUIDisabled;	
    private float timeLeft = 90;
    private float currentTime;

	void Start()
	{
		isGUIDisabled = true;
		failed = false;
		currentSpell3 = -1;
		currentSpell2 = -1;
		currentSpell1 = -1;
		currentTg = -1;
		cancelSpell = false;
	}

    void Update()
    {

        currentTime = timeLeft - Time.timeSinceLevelLoad;
        currentTime = Mathf.CeilToInt(currentTime);

        if (currentTime <= 0)
        {
            Time.timeScale = 0.00000000001f;
			failed = true;
        }
    }

	void OnGUI()
	{
       if(isGUIDisabled)
		{
			GUI.enabled = false;
		}
		else
		{	
			GUI.enabled = true;
		}

		currentTg = GUI.SelectionGrid(new Rect(Screen.width - 85, Screen.height / 2 - 112, 75, 75 * spellToggleTxt.Length), currentTg, spellToggleTxt, 1);

		switch(currentTg)
		{
			case 0:
			{	
				currentSpell2 = -1;
                scrollPosition2 = Vector2.zero;
				currentSpell3 = -1;
                scrollPosition3 = Vector2.zero;

                scrollPosition1 = GUI.BeginScrollView(new Rect(10, 10, 75, Screen.height - 10), scrollPosition1, new Rect(10, 10, 0, 75 * button_czerwony.Length + 10), GUIStyle.none, GUIStyle.none);
                currentSpell1 = GUI.SelectionGrid(new Rect(10, 10, 75, 75 * button_czerwony.Length), currentSpell1, button_czerwony, 1);
				GUI.EndScrollView();
			}
			break;
			case 1:
			{
				currentSpell1 = -1;
                scrollPosition1 = Vector2.zero;
				currentSpell3 = -1;
                scrollPosition3 = Vector2.zero;

                scrollPosition2 = GUI.BeginScrollView(new Rect(10, 10, 75, Screen.height - 10), scrollPosition2, new Rect(10, 10, 0, 75 * button_niebieski.Length + 10), GUIStyle.none, GUIStyle.none);
                currentSpell2 = GUI.SelectionGrid(new Rect(10, 10, 75, 75 * button_niebieski.Length), currentSpell2, button_niebieski, 1);
				GUI.EndScrollView();
			}
			break;
			case 2:
			{	
				currentSpell1 = -1;
                scrollPosition1 = Vector2.zero;
				currentSpell2 = -1;
                scrollPosition2 = Vector2.zero;

                scrollPosition3 = GUI.BeginScrollView(new Rect(10, 10, 75, Screen.height - 10), scrollPosition3, new Rect(10, 10, 0, 75 * button_zielony.Length + 10), GUIStyle.none, GUIStyle.none);
                currentSpell3 = GUI.SelectionGrid(new Rect(10, 10, 75, 75 * button_zielony.Length), currentSpell3, button_zielony, 1);
				GUI.EndScrollView();
			}
			break;
		}


        cancelSpell = GUI.Button(new Rect(Screen.width - 85, 10, 75, 75), cancelTex);


		if (cancelSpell) 
		{
			currentSpell1 = -1;
			currentSpell2 = -1;
			currentSpell3 = -1;
		}

        GUI.DrawTexture(new Rect(95, Screen.height - 37, Screen.width - 190, 27), TimeBackground);
        GUI.DrawTexture(new Rect(100, Screen.height - 32, Time.timeSinceLevelLoad * ((Screen.width - 200) / timeLeft), 17), TimeForeground, ScaleMode.ScaleAndCrop);

        GUI.DrawTexture(new Rect(95, Screen.height - 69, Screen.width - 190, 27), ManaBackground);
        GUI.DrawTexture(new Rect(100, Screen.height - 64, SpellsDefinitions.manaPool * ((Screen.width - 200) / 100), 17), ManaForeground, ScaleMode.ScaleAndCrop);


		if(failed)
		{
			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 -25, 100, 50),"Try again"))
			{
				failed = false;
				Application.LoadLevel(Application.loadedLevel);
			}

		}
		

	}
}
