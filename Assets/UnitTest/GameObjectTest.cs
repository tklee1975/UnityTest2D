using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class GameObjectTest : BaseTest {
	private SpaceShip mSpaceShip;

	void Start() {
		mSpaceShip = GameObject.Find("spaceShip").GetComponent<SpaceShip>();
	}

	[Test]
	public void test1()
	{
		Debug.Log("###### TEST 1 ######");
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
	[Test]
	public void RotateLeft() {
		mSpaceShip.RotateLeft(1);
	}
	[Test]
	public void RotateRight() {
		mSpaceShip.RotateRight(1);
	}
	[Test]
	public void MoveForeward()
	{
		float speed = 2;
		float time = 1;	// 1 second
		Transform transform = mSpaceShip.transform;

		//converting the object euler angle's magnitude from to Radians    
		float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;

		Vector3 myPos = transform.position;
		myPos.x += (Mathf.Sin (angle) * speed) * time;
		myPos.y -= (Mathf.Cos (angle) * speed) * time;

		transform.position = myPos;
		//mSpaceShip.transform.
	}
}
