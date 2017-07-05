using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class BasicTest : BaseTest {

	private GameObject mTestObject;

	void Start() {
		mTestObject = GameObject.Find("TestObject");
	}

	[Test]
	public void transformInfo()
	{

		Vector3 euler = mTestObject.transform.eulerAngles;		// euler is using degree
		Debug.Log("Transform.eulerAngle=" + euler);

		Vector3 forward = mTestObject.transform.forward;		// mag always 1
		Debug.Log("Transform.forward=" + forward + " mag=" + forward.magnitude);


		//Debug.Log("RotateX=" + 
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
