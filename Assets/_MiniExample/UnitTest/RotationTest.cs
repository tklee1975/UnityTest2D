using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class RotationTest : BaseTest {
	private GameObject mArrowObject;
	private Text mInfoText;
	private Vector2 mPressPosition;

	void Start() {
		// mTestObject
		mArrowObject = GameObject.Find("Arrow");
		mInfoText = GameObject.Find("InfoText").GetComponent<Text>();
	}

	void SetInfo(string info) {
		mInfoText.text = info;
	}

	void SetRotate(float angle) {
		Vector3 euler = mArrowObject.transform.eulerAngles;

		euler.z = angle;

		mArrowObject.transform.eulerAngles = euler;

		SetInfo("Rotation: " + euler.z);
	}

	void Rotate(float delta) {
		Vector3 euler = mArrowObject.transform.eulerAngles;

		euler.z += delta;

		mArrowObject.transform.eulerAngles = euler;

		SetInfo("Rotation: " + euler.z);
	}

	[Test]
	public void testRotateLeft()
	{
		Debug.Log("###### TEST 1 ######");
		Rotate(10);
	}

	[Test]
	public void testRotateRight()
	{
		Debug.Log("###### TEST 2 ######");
		Rotate(-10);
	}


	public float GetAngle( Vector2 a, Vector2 b ) {
		var an = a.normalized;
		var bn = b.normalized;
		var x = a.y - b.y;
		var y = b.x - a.x;
		return Mathf.Atan2(y, x) * Mathf.Rad2Deg;
	}

	[Test]
	public void testAngle()
	{
		//Vector2 from = new Vector2(1, 1);
		Vector2 from = Vector2.zero;	// new Vector2(0, 0);

		List<Vector2> list = new List<Vector2>();
		list.Add(new Vector2(0, 10));
		list.Add(new Vector2(10, 0));
		list.Add(new Vector2(10, 10));
		list.Add(new Vector2(1, 1));
		list.Add(new Vector2(1, 5));

		foreach(Vector2 to in list) {
			float angle = Vector2.Angle(from.normalized, to.normalized);
			float angle2 = GetAngle(from, to);
//			//float angle = Vector2.Angle(to, from);
//			Vector3 cross = Vector3.Cross(from, to);
//
//			if (cross.z > 0)
//				angle = 360 - angle;

			Debug.Log("to=" + to + " angle=" + angle + " angle2=" + angle2);

		}
	}

	void HandleRotateByMouse()
	{
		Vector3 pos3 = Input.mousePosition;
		Vector2 pos = new Vector2(pos3.x, pos3.y);

		//float angle = Vector2.Angle(mPressPosition, pos);
		float angle2 = GetAngle(mPressPosition, pos);
		SetRotate(angle2);
//		mArrowObject.transform.eulerAngles = angle2;
//		SetInfo("Angle=" + angle2);
//		pos.
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			mPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); 
		}

		if(Input.GetMouseButton(0)) {
			HandleRotateByMouse();
		}
	}
}
