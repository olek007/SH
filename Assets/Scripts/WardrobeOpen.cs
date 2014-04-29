using UnityEngine;
using System.Collections;

public class WardrobeOpen : MonoBehaviour {

	void openWardrobe()
	{
		gameObject.rigidbody.AddRelativeForce(0, 0, -0.0001f);
	}
}
