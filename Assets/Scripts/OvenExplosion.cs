using UnityEngine;
using System.Collections;

public class OvenExplosion : MonoBehaviour {

	public GameObject explosion;

	void explosionOven()
	{
		Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
	}
}
