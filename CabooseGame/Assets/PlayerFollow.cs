using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = 0.25f;
	public Vector3 offset;

	void Update()
	{

	}

	void LateUpdate()
	{
		transform.position = target.position + offset;
	}
}
