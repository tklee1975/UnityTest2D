using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AsteroidTest : BaseTest {
	private GameObject asteroidObject;
	void Start()
	{
		asteroidObject = GameObject.Find("PlaySpace/asteroid");
		Debug.Log("Asteroid object=" + asteroidObject);
	}

	[Test]
	public void SpawnAsteroid() {
		GameObject obj = GameObject.Find("AsteroidSpawner");
		AsteroidSpawner spawner = obj.GetComponent<AsteroidSpawner>();

		Debug.Log("spawner=" + spawner);

		spawner.SpawnAsteroid();
	}


	[Test]
	public void TestExplode() {
		Asteroid asteroid = asteroidObject.GetComponent<Asteroid>();

		asteroid.ShowExplosion();
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
