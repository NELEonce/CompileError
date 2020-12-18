using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyRotate : MonoBehaviour
{
	[SerializeField] Vector3 speed;	//回る速さ
	[SerializeField] Vector3 angle;	//角度 x,y,z

	void Update()
	{
		var t = Time.time * speed;
		transform.eulerAngles = new Vector3(
			(Mathf.PerlinNoise(t.x + 0, t.x + 0) - 0.5f) * angle.x,
			(Mathf.PerlinNoise(t.y + 1, t.y + 1) - 0.5f) * angle.y,
			(Mathf.PerlinNoise(t.z + 2, t.z + 2) - 0.5f) * angle.z);
	}
}
