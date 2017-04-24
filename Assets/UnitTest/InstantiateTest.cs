using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class InstantiateTest : BaseTest {
	public GameObject missilePrefab;
	public float speed = 1;
	public GameObject playSpace;

	void Start() {
		playSpace = GameObject.Find("PlaySpace");
	}


	[Test]
	public void CreateMissile()
	{
		GameObject missile = Instantiate(missilePrefab, 
					transform.position, Quaternion.identity) as GameObject;
		
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
		missile.transform.SetParent(playSpace.transform);
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
