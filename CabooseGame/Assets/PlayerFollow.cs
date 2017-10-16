using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = 0.25f;
	public Vector3 offset;
	private Vector3 previousPosition;
	void Update()
	{
		previousPosition = target.position;
	}

	void LateUpdate()
	{
		offset = Quaternion.AngleAxis (target.position.x * smoothSpeed, Vector3.up) * offset;
		if (previousPosition != target.position) {
			//transform.position = target.position + offset;
		}
		transform.LookAt (target);
	}
}
