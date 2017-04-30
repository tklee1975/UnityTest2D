using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class InstantiateTest : BaseTest {
	public GameObject missilePrefab;
	public GameObject asteroidPrefab;
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
	public void RotateAsteroid()
	{
		Asteroid asteroid = GameObject.Find("testAsteroid").GetComponent<Asteroid>();
		asteroid.RotateSelf(1);
	}

	[Test]
	public void SizedAsteroid()
	{
		Asteroid.Size[] allSize = { Asteroid.Size.Large, 
			Asteroid.Size.Medium, Asteroid.Size.Small, Asteroid.Size.Tiny};	

		Vector3 pos = new Vector3(-5, 0, 0);

		foreach(Asteroid.Size size in allSize) {
			GameObject obj = Instantiate(asteroidPrefab, pos, Quaternion.identity) as GameObject;
			obj.transform.SetParent(playSpace.transform);
			Asteroid asteroid = obj.GetComponent<Asteroid>();

			asteroid.SetSize(size);

			pos.x += 1;


		}
	}

	[Test]
	public void SpawnAsteroid()
	{
		float moveAngle = Random.Range(0, 360);
		float moveSpeed = 0.1f * Random.Range(6, 20);
		Vector3 position = Vector3.zero;
		Asteroid.Size size = (Asteroid.Size) Random.Range(0, (int) Asteroid.Size.Large);

		GameObject obj = Instantiate(asteroidPrefab, position, Quaternion.identity) as GameObject;
		obj.transform.SetParent(playSpace.transform);
		Asteroid asteroid = obj.GetComponent<Asteroid>();

		asteroid.SetSize(size);
		asteroid.moveSpeed = moveSpeed;
		asteroid.moveAngle = moveAngle;

	}

	[Test]
	public void UseSpawner() {
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
