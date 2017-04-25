using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {
	public float rotateSpeed = 45;
	public float speed = 5;
	public float force = 1f;
	public Bounds bound = new Bounds(new Vector3(0, 2, 0), new Vector3(15, 10, 0));
	private float mCurrentSpeed = 0;

	// Use this for initialization
	void Start () {
		
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
		myPos.x += (Mathf.Sin (angle) * speed) * delta;
		myPos.y -= (Mathf.Cos (angle) * speed) * delta;


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

		} else if(Input.GetKey(KeyCode.DownArrow)){
			mCurrentSpeed = 0;
		} else {
			mCurrentSpeed -= force * 0.5f * Time.deltaTime;
			mCurrentSpeed = Mathf.Max(mCurrentSpeed, 0);
		}
		HandleShipMove();

		// 
	}
}
