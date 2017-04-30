using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AsteroidTest : BaseTest {
	[Test]
	public void SpawnAsteroid() {
		GameObject obj = GameObject.Find("AsteroidSpawner");
		AsteroidSpawner spawner = obj.GetComponent<AsteroidSpawner>();

		Debug.Log("spawner=" + spawner);

		spawner.SpawnAsteroid();
	}

	[Test]
	public void StartSpawner() {
		GameObject obj = GameObject.Find("AsteroidSpawner");
		AsteroidSpawner spawner = obj.GetComponent<AsteroidSpawner>();
		spawner.StartSpawn();
	}

	[Test]
	public void StopSpwaner() {
		GameObject obj = GameObject.Find("AsteroidSpawner");
		AsteroidSpawner spawner = obj.GetComponent<AsteroidSpawner>();
		spawner.StopSpawn();
	}
}
