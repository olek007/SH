using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public int szybkosc = 100;

	void Update() 
	{
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") != 0.0f)
            {
                transform.Translate(-Input.GetAxis("Mouse X") * szybkosc * Time.deltaTime, 0, 0);
                if (Input.GetAxis("Mouse Y") != 0.0f)
                {
                    transform.Translate(0, -Input.GetAxis("Mouse Y") * szybkosc * Time.deltaTime, 0);
                }
            }
        }
	}
}
