using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieAI : MonoBehaviour {

	public static List<GameObject> NPCsInside = new List<GameObject>();
	private NavMeshAgent agent;
	private int randomNPC;

	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		Destroy(gameObject, 6.0f);
		randomNPC = Random.Range(0, NPCsInside.Count);
		agent.destination = NPCsInside[randomNPC].transform.position;
	}
	

	void Update () 
	{
		if (Vector3.Distance(gameObject.transform.position, NPCsInside[randomNPC].transform.position) > 1.0f)
		{
			agent.destination = NPCsInside[randomNPC].transform.position;
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "GameController")
		{
			collider.gameObject.SendMessage("addFear", (SpellsDefinitions.spells2Dmg[2]) * Time.deltaTime);
		}
	}
}
