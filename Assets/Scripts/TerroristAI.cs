using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerroristAI : MonoBehaviour {
	
	NavMeshAgent agent;
	public Transform room;
	

	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		agent.destination = room.position;
	}
	

	void Update () 
	{
		if(Vector3.Distance(gameObject.transform.position,room.transform.position)<1.0f)
		{
			Destroy(gameObject);
			
		}
	}
}
