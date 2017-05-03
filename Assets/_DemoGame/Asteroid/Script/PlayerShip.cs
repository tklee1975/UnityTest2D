using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {
	public float rotateSpeed = 45;
	public float speed = 5;
	public float force = 1f;
	public float brakeFactor = 3f;
	public Bounds bound = new Bounds(new Vector3(0, 2, 0), new Vector3(15, 10, 0));
	private float mCurrentSpeed = 0;
	private KeyCode mLastKey = KeyCode.None;
	public GameObject missilePrefab;
	public bool isHitting = false; 

	public bool isDebugMode;

	// Use this for initialization
	void Start () {
		
	}

	public void Fire()
	{
		GameObject missile = Instantiate(missilePrefab, 
			transform.position, Quaternion.identity) as GameObject;


		missile.transform.eulerAngles = transform.eulerAngles;
		missile.transform.SetParent(transform.parent);

		PlayerMissile missileBehaviour = missile.GetComponent<PlayerMissile>();
		missileBehaviour.enableMove = true;
		if(speed > missileBehaviour.moveSpeed) {
			missileBehaviour.moveSpeed = speed;
		}
	}

	public void SetSmokeVisible(bool show)
	{
		int childCount = transform.childCount;
		for(int i=0; i<childCount; i++) {
			Transform t = transform.GetChild(i);
			if(t.name == "smoke") {
				t.GetComponent<Renderer>().enabled = show;
			}
		}
	}

	public void MoveShip(float delta) {
		//converting the object euler angle's magnitude from to Radians    
		float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;

		Vector3 myPos = transform.position;
		myPos.x += (Mathf.Sin (angle) * mCurrentSpeed) * delta;
		myPos.y -= (Mathf.Cos (angle) * mCurrentSpeed) * delta;


		// Clamping
		Vector3 min = bound.min;
		Vector3 max = bound.max;
		myPos.x = Mathf.Clamp(myPos.x, min.x, max.x);
		myPos.y = Mathf.Clamp(myPos.y, min.y, max.y);


		transform.position = myPos;
	}

	public void HandleShipMove()
	{
		if(mCurrentSpeed == 0){ 
			SetSmokeVisible(false);
		} else {
			SetSmokeVisible(true);
			MoveShip(Time.deltaTime);
		}
	}

	public void RotateLeft(float delta) {
		Vector3 angle = new Vector3(0, 0, rotateSpeed * delta);
		transform.Rotate(angle);
	}


	public void RotateRight(float delta) {
		Vector3 angle = new Vector3(0, 0, -rotateSpeed * delta);
		transform.Rotate(angle);
	}


	void HandleDirectionChange(KeyCode key)
	{
		if(mLastKey == KeyCode.None) {
			mLastKey = key;
		}

		if(key != mLastKey){ 
			mLastKey = key;

			Vector3 angle = new Vector3(0, 0, 180);
			transform.Rotate(angle);
		}

	}



	void Update()
	{
		// Controlling the Angle 
		if(Input.GetKey(KeyCode.LeftArrow)){
			RotateLeft(Time.deltaTime);
		} else if(Input.GetKey(KeyCode.RightArrow)){
			RotateRight(Time.deltaTime);
		} 

		// Controlling the Speed
		if(Input.GetKey(KeyCode.UpArrow)) {
			mCurrentSpeed += force * Time.deltaTime;;
			mCurrentSpeed = Mathf.Min(mCurrentSpeed, speed);
		} else if(Input.GetKey(KeyCode.DownArrow)) { 
			mCurrentSpeed -= force * brakeFactor * Time.deltaTime;
			mCurrentSpeed = Mathf.Max(mCurrentSpeed, 0);
		}

		HandleShipMove();

		// Control the fire
		if(Input.GetKeyDown(KeyCode.Space)) {
			Fire();
		}
		// 
	}

	void Explode()
	{
		if(gameObject.activeInHierarchy == false) {
			return;
		}

		isHitting = true;

		//GameObject.Destroy(this.gameObject);
		if(isDebugMode) {
			transform.position = Vector3.zero;
			return;
		}

		// Actual 
		Debug.Log("PlayerShip.Explode");
		AsteroidManager.Instance.HandlePlayerHit();

	}

	// Possible Collide 
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("collision detected: hit by " + coll.gameObject.tag);


		if(coll.gameObject.tag == "Enemy") {
			if(isHitting) {
				return;
			}
			GameObject.Destroy(coll.gameObject);
			Explode();	
		}

//		if (coll.gameObject.tag == "Enemy") {
//			coll.gameObject.SendMessage("ApplyDamage", 10);
//		}
	}

}
