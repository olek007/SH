using UnityEngine;
using System.Collections;

public class NPC_RandomMovement : MonoBehaviour {


    public GameObject PokojTrigger;


    void OnTriggerExit(Collider cos)
    {
        if (cos.isTrigger)
        {
            transform.position = PokojTrigger.transform.position+ new Vector3 (Random.Range(-4, 5), 0, Random.Range(-4, 5));
        }
        
    }

    
    void zerowanie()
    {
        transform.position = PokojTrigger.transform.position;
    }

    void dodawanie(string numerPokoju)
    {
		PokojTrigger = GameObject.Find("Room_" + numerPokoju + "_Trigger");
    }
    
}
