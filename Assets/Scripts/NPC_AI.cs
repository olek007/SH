using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_AI : MonoBehaviour {
	
   	public NavMeshAgent agent;
    public Transform exit;
    public float fearLevel;
	public float fearLevelDecreaseRate = 1.0f;
	public float fearSusceptibility = 1.0f;
	public GameObject [] waypoints;
	public List<NPC_AI> NPCs = new List<NPC_AI>();
	public GameObject [] people;

	void Start () 
	{
        agent = gameObject.GetComponent<NavMeshAgent>();


		people = GameObject.FindGameObjectsWithTag("GameController");

		foreach(GameObject NPC in people)
		{
			if(NPC != gameObject)
			{
				NPCs.Add(NPC.GetComponent<NPC_AI>());
			}
		}

		InvokeRepeating("ChangePlace",0,Random.Range(8.0f,10.0f));
		
	}

	void Update () 
	{
		if(!GhostAI.NPCsInside.Contains (gameObject))
		{
			GhostAI.NPCsInside.Add(gameObject);
		}
		
		if(Vector3.Distance(transform.position, agent.destination) <= 1.5f)
		{
			agent.Stop();
		}


        if (fearLevel >= 100.0f)
        {
			GhostAI.NPCsInside.Remove(gameObject);
	        agent.destination = exit.position;
			CancelInvoke();
	        agent.speed = 3.5f;

            if (Vector3.Distance(transform.position, exit.transform.position) <= 1.5f)
            {
                Destroy(gameObject);
            }
        }
	}

	void LateUpdate()
	{
		if(fearLevel>0)
		fearLevel = (fearLevel - (fearLevelDecreaseRate * Time.deltaTime));
	}

	public void addFear(float fearAmount)
	{
		fearLevel += fearAmount;
		ChangePlace();
	}

	public float ReportFearSusceptibility()
	{
		return fearSusceptibility;	
	}

	void ChangePlace()
	{
		agent.destination = waypoints[Random.Range(0,waypoints.Length)].transform.position;
		do
		{
			agent.destination = waypoints[Random.Range(0,waypoints.Length)].transform.position;

		}while(CheckIfDestinationIsCorrect(agent.destination) == false);
	}

	bool CheckIfDestinationIsCorrect( Vector3 destination)
	{
		foreach(NPC_AI NPC in NPCs)
		{

			if(Vector3.Distance(NPC.agent.destination,destination)<=1.0f)
			{
				return false;
			}

		}
		return true;
	}
	

}
