using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 260f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	private KeyCode previousKey;

	void Awake() 
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Move (h, v);
		Rotate ();
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		movement = new Vector3(h, 0f, v) * speed * Time.deltaTime;

		if (isWalking (h, v)) {
			movement = transform.forward * speed * Time.deltaTime;
		}

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Rotate()
	{
		// Rotate right
		if (Input.GetKey (KeyCode.X)) {
			transform.Rotate(Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.Z)) { // Rotate left
			transform.Rotate(-Vector3.up * speed * Time.deltaTime);
		}
	}

	void Animating(float h, float v)
	{
		anim.SetBool ("isWalking", isWalking(h, v));

		if (Input.GetKey (KeyCode.Space)) {
			anim.SetTrigger ("jump");
		}
	}

	private bool isWalking(float h, float v) 
	{
		if (h != 0f || v != 0f)
			return true;
		else
			return false;
	}
}
