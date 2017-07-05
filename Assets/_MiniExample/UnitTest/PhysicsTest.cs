using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class PhysicsTest : BaseTest {

	public GameObject activeBall;

	public float rotateSpeed = 180;

	public float ballSpeed = 100;

	public float moveSpeed = 100;

	public float ballStrength = 5;

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


	private void Rotate(int direction) {		// direction = -1  ? 
		Vector3 euler = activeBall.transform.eulerAngles;
		euler.z += Time.deltaTime * rotateSpeed * direction;

		activeBall.transform.eulerAngles = euler;
	}

	private void AddForce() {
		// Vector3 foreward = activeBall.transform.forward;
		//body


		//activeBall.transform.
		//Quaternion q 
		Rigidbody2D body = activeBall.GetComponent<Rigidbody2D>();
		float rotation = body.rotation;
		float x = -Mathf.Sin(Mathf.Deg2Rad * rotation);
		float y =  Mathf.Cos(Mathf.Deg2Rad * rotation);
		Vector2 foreward2D = new Vector2(x, y).normalized;

		body.AddForce(foreward2D * ballStrength, ForceMode2D.Impulse);
	}

	private void StopBall() {
		Rigidbody2D body = activeBall.GetComponent<Rigidbody2D>();
		body.velocity = Vector2.zero;
		body.angularVelocity = 0;
	}

	public void Update() {
		// Update Speed

		// Control
		if(Input.GetKey(KeyCode.LeftArrow)){
			Rotate(1);
		} else if(Input.GetKey(KeyCode.RightArrow)){
			Rotate(-1);
		} else if(Input.GetKey(KeyCode.A)){
			AddForce();
		} else if(Input.GetKey(KeyCode.S)){
			StopBall();
		}
	}
}
