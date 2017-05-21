using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
// https://forum.unity3d.com/threads/is-there-a-way-to-simulate-the-touch-using-the-mouse.54800/
// http://answers.unity3d.com/questions/448771/simulate-touch-with-mouse.html
public class InputTest : BaseTest {
	enum TestCase {
		TestKeyPress,
		TestKeyClick,
		TestButton,
		TestTouch,
	}

	public GameObject shineParticle;
	public GameObject fireParticle;

	private TestCase mTestCase = TestCase.TestKeyClick;
	private GameObject mTestObject;
	private Text mTestNameText;

	void Start() {
		mTestObject = GameObject.Find("TestObject");

		GameObject testObject = GameObject.Find("TestGUI/TestText");
		mTestNameText = testObject.GetComponent<Text>();

		//TestKeyClick();
		TestButton();
	}

	private void MoveObject(Vector2 delta)
	{
		Vector3 newPos = mTestObject.transform.position + new Vector3(delta.x, delta.y, 0);

		mTestObject.transform.position = newPos;
	}

	private void SpawnFire(Vector3 position)
	{
		SpawnParticle(fireParticle, position);
	}

	private void SpawnShine(Vector3 position)
	{
		SpawnParticle(shineParticle, position);
	}

	private void SpawnParticle(GameObject sourceParticle, Vector3 position)
	{
		GameObject parent = GameObject.Find("PlaySpace");

		GameObject particle = Instantiate(sourceParticle, 
			position, Quaternion.identity) as GameObject;
		Vector3 eulerAngles = parent.transform.eulerAngles;
		eulerAngles.x = -90;
		particle.transform.eulerAngles = eulerAngles;
		particle.transform.SetParent(parent.transform);

		float duration = particle.GetComponent<ParticleSystem>().main.duration;
		Destroy(particle, duration);
	}


	private void SetTestName(string name) {
		mTestNameText.text = name;
	}

	[Test]
	public void TestKeyClick()
	{
		Debug.Log("Testing Key");
		mTestCase = TestCase.TestKeyClick;
		SetTestName("Testing KeyClick");
	}

	[Test]
	public void TestKeyPress()
	{
		Debug.Log("Testing Key");
		mTestCase = TestCase.TestKeyPress;
		SetTestName("Testing KeyPress");
	}

	[Test]
	public void TestButton()
	{
		Debug.Log("Testing Button");
		mTestCase = TestCase.TestButton;
		SetTestName("Testing Button");
	}

	[Test]
	public void TestTouch()
	{
		Debug.Log("Testing TestTouch");
		mTestCase = TestCase.TestTouch;
		SetTestName("Testing Touch");
	}

//	void MoveStar(Vector2 dir) {
//		Vector3 current = mTestObject.
//	}

	//  Testing input using GetKeyDown or GetKeyUp  as you like 
	// 	 You need to call this function from the Update function, since the state gets reset each frame. It will not return true until the user has released the key and pressed it again.
	void UpdateForTestKeyClick()
	{
		bool usingKeyDown = true;
		float moveDelta = 0.2f;

		if(usingKeyDown) {
			if (Input.GetKeyDown("down")) {
				print("down key was pressed");

				MoveObject(new Vector2(0, -moveDelta));
			} else if(Input.GetKeyDown("up")) {
				print("up key was pressed");
				MoveObject(new Vector2(0, moveDelta));
			} else if(Input.GetKeyDown("left")) {
				print("left key was pressed");
				MoveObject(new Vector2(-moveDelta, 0));
			} else if(Input.GetKeyDown("right")) {
				print("right key was pressed");
				MoveObject(new Vector2(moveDelta, 0));

			}
				
		} else {

			if (Input.GetKeyUp("down")) {
				print("down key was pressed");

				MoveObject(new Vector2(0, -moveDelta));
			} else if(Input.GetKeyUp("up")) {
				print("up key was pressed");
				MoveObject(new Vector2(0, moveDelta));
			} else if(Input.GetKeyUp("left")) {
				print("left key was pressed");
				MoveObject(new Vector2(-moveDelta, 0));
			} else if(Input.GetKeyUp("right")) {
				print("right key was pressed");
				MoveObject(new Vector2(moveDelta, 0));

			}
		}

	}

	void UpdateForTestKeyPress()
	{
		float moveSpeed = 5.0f;
		float moveDelta = moveSpeed * Time.deltaTime;

		Vector2 delta = new Vector2();



		if (Input.GetKey("down")) {
			print("down key was pressed");
			delta.y = -moveDelta;
		} else if(Input.GetKey("up")) {
			print("up key was pressed");
			delta.y = moveDelta;
		} 

		if(Input.GetKey("left")) {
			print("left key was pressed");
			delta.x = -moveDelta;
		} else if(Input.GetKey("right")) {
			print("right key was pressed");
			delta.x = moveDelta;
		}

		MoveObject(delta);
	}

	void UpdateForTestButton()
	{

		float moveSpeed = 5.0f;

		Vector2 delta = new Vector2();

		delta.y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		delta.x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;


		if(delta.x != 0 || delta.y != 0) {
			MoveObject(delta);
		}
		

		if (Input.GetButton("Fire1"))
		{
			print("Fire1 Button was pressed");
			SpawnFire(mTestObject.transform.position);
		}

		if (Input.GetButtonDown("Fire2"))		// just once before ButtonUp
		{
			print("Fire2 Button was pressed");
			SpawnShine(mTestObject.transform.position);
		}
	}

	void UpdateForTestTouch()
	{
		// 
		if(Input.touchCount <= 0) {
			return;
		}

		print("TestCount: " + Input.touchCount);

		for (int i = 0; i < Input.touchCount; ++i)
		{
			
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				print("Touch " + i + " is began!!");
			}

		}
	}


	void Update() {
		switch(mTestCase) {
			case TestCase.TestButton: {
				UpdateForTestButton();
				break;
			}

			case TestCase.TestKeyClick: {
				UpdateForTestKeyClick();
				break;
			}

			case TestCase.TestKeyPress: {
				UpdateForTestKeyPress();
				break;
			}

			case TestCase.TestTouch: {
				UpdateForTestTouch();
				break;
			}
		}




	}
}
