using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public float moveAngleRad = 0;
	public bool enableMove = false;

	public Bounds bound; 

	// Use this for initialization
	void Start () {
		moveAngleRad = transform.eulerAngles.z * Mathf.Deg2Rad;

		// Define the bound
		bound = CamHelper.getCameraBounds();
		bound.Expand(2);
	}


	public void OnDrawGizmos() {
		float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
		//float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
		Vector3 target = transform.position;
		target.x += Mathf.Sin (angle) * 1;
		target.y -= Mathf.Cos (angle) * 1;

		Gizmos.DrawLine(transform.position, target);
	}



	public void Move(float delta)
	{
		float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
		Vector3 deltaPos = Vector3.zero;

		deltaPos.x = (Mathf.Sin (angle) * moveSpeed) * delta;
		deltaPos.y = -(Mathf.Cos (angle) * moveSpeed) * delta;

		// Debug.Log("Asteroid.Move: " + deltaPos.x + " y=" + deltaPos.y);
		Vector3 pos = transform.position;
		pos += deltaPos;

		transform.position = pos;
	}

	private bool HandleCleanup()
	{
		if(bound.Contains(transform.position) == false) {
			//Debug.Log("Try to remove this asteroid");
			Object.Destroy(gameObject);
			return true;
		}

		return false;
	}


	// Update is called once per frame
	void Update () {
		if(HandleCleanup()) {
			return;
		}

		if(enableMove) {
			Move(Time.deltaTime);
		}
	}

	// Possible Collide 
	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log("Missile: collision detected: hit by " + coll.gameObject.tag);

	}

}
