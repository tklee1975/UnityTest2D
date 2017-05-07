using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class PlayerShipTest : BaseTest {
	private PlayerShip mPlayerShip;
	public GameObject missilePrefab;
	public GameObject playSpace;

	void Start() {
		mPlayerShip = GameObject.Find("PlayerShip").GetComponent<PlayerShip>();
	}

	[Test]
	public void testExplode()
	{
		mPlayerShip.ShowExplodeParticle();
	}


	[Test]
	public void testMissile()
	{
		GameObject missile = Instantiate(missilePrefab, 
			transform.position, Quaternion.identity) as GameObject;


		missile.transform.eulerAngles = missilePrefab.transform.eulerAngles;
		missile.transform.SetParent(playSpace.transform);
		PlayerMissile missileBehaviour = missile.GetComponent<PlayerMissile>();
		missileBehaviour.enableMove = true;
		if(mPlayerShip.speed > missileBehaviour.moveSpeed) {
			missileBehaviour.moveSpeed = mPlayerShip.speed;
		}

	}


	[Test]
	public void testFire()
	{
		Debug.Log("###### TEST 1 ######");
		mPlayerShip.Fire();
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
