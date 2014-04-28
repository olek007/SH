using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeadGirlAI : MonoBehaviour {

	private List<GameObject> NPCsInside = new List<GameObject>();
	private GameObject room;
	
	private Light [] lights;


	void Start () 
	{
		Destroy(gameObject, 2.0f);
	}


	void OnTriggerStay(Collider collider)
	{

		if(collider.gameObject.tag == "GameController")
		{
		NPC_AI NPC = collider.gameObject.GetComponent<NPC_AI>();
			NPC.addFear((SpellsDefinitions.spells2Dmg[0] / NPCsInside.Count) * 1.5f * NPC.ReportFearSusceptibility() * Time.deltaTime);
		}
	
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "GameController" && collider.GetComponent<NPC_AI>().fearLevel < 100)
		{
			NPCsInside.Add(collider.gameObject);

		}
		else if(collider.tag == "RoomTrigger")
		{
			room = collider.gameObject.transform.parent.gameObject;			
			lights = room.GetComponentsInChildren<Light>();
		
			foreach(Light light in lights)
			{
				light.enabled = false;	
			}
			
		}
	}
	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "GameController")
		{
			NPCsInside.Remove(collider.gameObject);
		}
	}
	
	void OnDestroy()
	{
		foreach (Light light in lights)
		{
			light.enabled = true;	
		}	
	}

}
