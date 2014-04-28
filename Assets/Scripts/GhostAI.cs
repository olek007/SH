using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GhostAI : MonoBehaviour {

	public static List<GameObject> NPCsInside = new List<GameObject>();
	private Transform targetPosition;
	public int movementSpeed = 5;
	
	
	void Start () 
	{
		Destroy(gameObject, 3.0f);
		targetPosition=NPCsInside[Random.Range(0,NPCsInside.Count)].transform;
	}
	
	void Update()
    {
		if(Vector3.Distance(gameObject.transform.position,targetPosition.position)>=1.0f)
		{
			if(transform.position.x<=targetPosition.position.x)
			{
				if(transform.position.z<targetPosition.position.z)
				{
				transform.Translate(new Vector3(1,0,1) * movementSpeed * Time.deltaTime);
				}else
				{
				transform.Translate(new Vector3(1,0,-1) * movementSpeed * Time.deltaTime);
				}
			}else
			{
				if(transform.position.z<=targetPosition.position.z)
				{
				transform.Translate(new Vector3(-1,0,1) * movementSpeed * Time.deltaTime);
				}else
				{
				transform.Translate(new Vector3(-1,0,-1) * movementSpeed * Time.deltaTime);
				}
			}

		}
	}
	
	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "GameController")
		{
			collider.gameObject.SendMessage("addFear", (SpellsDefinitions.spells2Dmg[1]) * Time.deltaTime);
		}
	}

}

