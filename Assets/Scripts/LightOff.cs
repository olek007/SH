using UnityEngine;
using System.Collections;

public class LightOff : MonoBehaviour {


	private float time;

	void Start()
	{
		time = SpellsDefinitions.spells1Cooldown[0];
	}

	void Update()
	{
		if (gameObject.light.enabled == false)
		{
			time -= Time.deltaTime;
		}

		if (time <= 0)
		{
			gameObject.light.enabled = true;
			time =  SpellsDefinitions.spells1Cooldown[0];
		}
	}

	void TurnOff()
	{
		gameObject.light.enabled = false;
	}
}
