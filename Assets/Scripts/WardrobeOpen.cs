using UnityEngine;
using System.Collections;

public class WardrobeOpen : MonoBehaviour {



	 void Start()
	{
	}

	void OnMouseDown()
	{
		Debug.Log(SpellsGUI.currentSpell1);
		if(SpellsGUI.currentSpell1==0)
		{

			gameObject.rigidbody.AddRelativeForce(0,0,-0.00005f);
		}
	}
}
