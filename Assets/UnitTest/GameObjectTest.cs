using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class GameObjectTest : BaseTest {
	private SpaceShip mSpaceShip;
	private GameObject mTestShip;
	private bool mSmokeVisibility = true;
	public Bounds bound = new Bounds(new Vector3(0, 2, 0), new Vector3(15, 10, 0));
	//public Vector2 mBound = new Vector2(15, 8);

	void Start() {
		mSpaceShip = GameObject.Find("spaceShip").GetComponent<SpaceShip>();
		mSpaceShip.bound = bound;
		mTestShip = GameObject.Find("testShip");
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(bound.center, bound.size);
	}

	[Test]
	public void ResetPosition()
	{
		mSpaceShip.transform.position = Vector3.zero;
		mTestShip.transform.position = Vector3.zero;
	}

	[Test]
	public void ToggleSmoke()
	{
		// For Test Ship 
		mSmokeVisibility = ! mSmokeVisibility;

		int childCount = mTestShip.transform.childCount;
		for(int i=0; i<childCount; i++) {
			Transform t = mTestShip.transform.GetChild(i);
			if(t.name == "smoke") {
				t.GetComponent<Renderer>().enabled = mSmokeVisibility;
			}
		}

		// Ship Prefab
		// See mSpaceShip.SetSmokeVisible
			
	}

	[Test]
	public void RotateRight() {

		// For Test Ship
		Vector3 angle = new Vector3(0, 0, -10);
		mTestShip.transform.Rotate(angle);

		//Ship Prefab 
		mSpaceShip.RotateRight(1);
	}
	[Test]
	public void RotateLeft() {
		// Test Ship
		Vector3 angle = new Vector3(0, 0, 10);
		mTestShip.transform.Rotate(angle);

		// Ship Prefab 
		mSpaceShip.RotateLeft(1);
	}

	[Test]
	public void MoveForeward()
	{
		// Test Ship
		float speed = 2;
		float time = 1;	// 1 second
		Transform transform = mTestShip.transform;

		//converting the object euler angle's magnitude from to Radians    
		float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;

		Vector3 myPos = transform.position;
		myPos.x += (Mathf.Sin (angle) * speed) * time;
		myPos.y -= (Mathf.Cos (angle) * speed) * time;

		// 
		Vector3 min = bound.min;
		Vector3 max = bound.max;
		myPos.x = Mathf.Clamp(myPos.x, min.x, max.x);
		myPos.y = Mathf.Clamp(myPos.y, min.y, max.y);

		transform.position = myPos;

		// OR 
		mSpaceShip.MoveShip(1);
	}
}
