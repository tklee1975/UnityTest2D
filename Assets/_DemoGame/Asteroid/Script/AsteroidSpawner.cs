using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	public float spawnRange = 60;		// 60 degree
	public float minSpeed = 1;
	public float maxSpeed = 5;
	public GameObject asteroidPrefab;
	public GameObject spawnParent;

	public float spawnInterval = 0.5f; // seconds

	private bool mIsSpawning;
	private float mSpawnCooldown = 0;

	// Use this for initialization
	void Start () {
		if(spawnParent == null) {
			spawnParent = transform.parent.gameObject;
		}		
	}
	
	// Update is called once per frame
	void Update () {
		CheckAndSpawn();
	}

	private void CheckAndSpawn()
	{
		if(mIsSpawning == false) {
			return;
		}

		mSpawnCooldown -= Time.deltaTime;
		if(mSpawnCooldown > 0) {
			return;
		}

		SpawnAsteroid();

		mSpawnCooldown = spawnInterval;
	}

	public void StartSpawn() {
		mIsSpawning = true;
	}

	public void StopSpawn() {
		mIsSpawning = false;
	}

	public void SpawnAsteroid() {
		float spawnAngle = transform.eulerAngles.z;
		// Half Range
		float halfRange = spawnRange / 2;

		// Draw of the Angle	
		int rightAngle = (int) (spawnAngle + halfRange) % 360;
		int leftAngle = (int) (spawnAngle - halfRange) % 360;
		int minAngle = Mathf.Min(leftAngle, rightAngle);
		int maxAngle = Mathf.Max(leftAngle, rightAngle);


		float moveAngle = Random.Range(minAngle, maxAngle);
		float moveSpeed = Random.Range(minSpeed, maxSpeed);
		Vector3 position = transform.position;
		Asteroid.Size size = (Asteroid.Size) Random.Range(0, (int) Asteroid.Size.Large);

		GameObject obj = Instantiate(asteroidPrefab, position, Quaternion.identity) as GameObject;
		obj.transform.SetParent(spawnParent.transform);
		Asteroid asteroid = obj.GetComponent<Asteroid>();

		asteroid.SetSize(size);
		asteroid.moveSpeed = moveSpeed;
		asteroid.moveAngle = moveAngle;
	}

	// Gizmo
	public void OnDrawGizmos() {
		float spawnAngle = transform.eulerAngles.z;

		// Half Range
		float halfRange = spawnRange / 2;

		// Draw of the Angle	
		int rightAngle = (int) (spawnAngle + halfRange) % 360;
		int leftAngle = (int) (spawnAngle - halfRange) % 360;
		float angle;
		Vector3 target;
		Debug.Log("Gizmo: angle=" + spawnAngle + " rAngle=" + rightAngle + " lAngle=" + leftAngle);

		// Left Range
		angle = spawnAngle * Mathf.Deg2Rad;
		target = transform.position;
		target.x += Mathf.Sin (angle) * 1;
		target.y -= Mathf.Cos (angle) * 1;
		Gizmos.DrawLine(transform.position, target);

		// Left Range
		angle = leftAngle * Mathf.Deg2Rad;
		target = transform.position;
		target.x += Mathf.Sin (angle) * 1;
		target.y -= Mathf.Cos (angle) * 1;
		Gizmos.DrawLine(transform.position, target);

		// Right Range
		angle = rightAngle * Mathf.Deg2Rad;
		target = transform.position;
		target.x += Mathf.Sin (angle) * 1;
		target.y -= Mathf.Cos (angle) * 1;
		Gizmos.DrawLine(transform.position, target);

	}
}
