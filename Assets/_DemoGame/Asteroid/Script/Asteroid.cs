using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplodeBehaviour))]
public class Asteroid : MonoBehaviour {
	public enum Size {
		Tiny,
		Small,
		Medium,
		Large,
	};

	public Size asteroidSize = Size.Large;
	public float moveAngle = 0f;		// in degree
	public float moveSpeed = 0f;
	public float selfRotateSpeed = 50.0f;

	public bool hasSeen = false;
	public bool isDebugMode = false;

	public Bounds bound; 

	private Transform mSpriteTransform;

	void Start() {
		mSpriteTransform = transform.Find("image");

		// Define the bound
		bound = CamHelper.getCameraBounds();
		bound.Expand(2);
	}

	public void ShowExplosion()
	{
		GetComponent<ExplodeBehaviour>().ShowExplosion();
	}

	public void OnDrawGizmos() {
		//float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
		float angle = moveAngle * Mathf.Deg2Rad;
		Vector3 target = transform.position;
		target.x += Mathf.Sin (angle) * 1;
		target.y -= Mathf.Cos (angle) * 1;

		Gizmos.DrawLine(transform.position, target);
	}

	public void RotateSelf(float delta)
	{
		// Debug.Log("RotateSelf: Debug: " + mSpriteTransform);
		Vector3 rotateVec = new Vector3(0, 0, selfRotateSpeed * delta);
		mSpriteTransform.Rotate(rotateVec);
	}

	public void Move(float delta)
	{
		Vector3 deltaPos = Vector3.zero;

		float angleRad = moveAngle * Mathf.Deg2Rad;
		deltaPos.x = (Mathf.Sin (angleRad) * moveSpeed) * delta;
		deltaPos.y = - (Mathf.Cos (angleRad) * moveSpeed) * delta;

		//Debug.Log("Asteroid.Move: " + deltaPos);

		transform.Translate(deltaPos);
	}

	public void SetSize(Size size)
	{
		float scale;

		// determine the scale by the size enum
		if(Size.Large == size) {
			scale = 1.0f;
		}else if(Size.Medium == size) {
			scale = 0.5f;
		}else if(Size.Small == size) {
			scale = 0.3f;
		} else { // Tiny
			scale = 0.1f;
		}




		// Set the size
		Vector3 sizeVec = new Vector3(scale, scale, scale);
		transform.localScale = sizeVec;
	}
		
	private void CheckSeenStatus()
	{
		if(hasSeen) {
			return;
		}

		hasSeen = bound.Contains(transform.position);
	}

	private bool HandleCleanup()
	{
		if(hasSeen == false) {
			return false;
		}

		if(bound.Contains(transform.position) == false) {
			//Debug.Log("Try to remove this asteroid");
			Object.Destroy(gameObject);
			return true;
		}

		return false;
	}

	// Update is called once per frame
	void Update () {
		CheckSeenStatus();

		if(HandleCleanup()) {
			return;
		}

		// 
		RotateSelf(Time.deltaTime);
		Move(Time.deltaTime);
	}

	void Explode()
	{
		
		GameObject.Destroy(this.gameObject);

		AsteroidManager.Audio.PlayAsteroidHit();

		AsteroidManager.Instance.HandleEnemyHit();

		ShowExplosion();
	}


	// Possible Collide 
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("Asteroid: collision detected: hit by " + coll.gameObject.tag);

		if(coll.gameObject.tag == "Missile") {
			Explode();	
			GameObject.Destroy(coll.gameObject);
		}
	}
}
