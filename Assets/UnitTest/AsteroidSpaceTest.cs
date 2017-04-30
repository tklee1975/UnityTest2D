using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AsteroidSpaceTest : BaseTest {
	[Test]
	public void StartSpawner()
	{
		AsteroidSpace space = GameObject.Find("AsteroidSpace").GetComponent<AsteroidSpace>();
		space.StartSpawn();
	}

	[Test]
	public void StopSpawner()
	{
		AsteroidSpace space = GameObject.Find("AsteroidSpace").GetComponent<AsteroidSpace>();
		space.StopSpawn();
	}
}
