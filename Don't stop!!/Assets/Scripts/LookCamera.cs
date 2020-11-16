using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{

	void Update()
	{
		Vector3 p = Camera.main.transform.position;
		p.y = transform.position.y;
		transform.LookAt(p);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
	}
}