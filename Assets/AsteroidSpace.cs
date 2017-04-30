using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpace : MonoBehaviour {
	public Bounds bound = new Bounds(new Vector3(0, 2, 0), new Vector3(15, 10, 0));

	List<AsteroidSpawner> mSpawnerList = new List<AsteroidSpawner>();

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(bound.center, bound.size);
	}

	// Use this for initialization
	void Start () {
		GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
		foreach(GameObject obj in spawners) {
			AsteroidSpawner spawner = obj.GetComponent<AsteroidSpawner>();
			mSpawnerList.Add(spawner);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawn() {
		foreach(AsteroidSpawner spawner in mSpawnerList) {
			spawner.StartSpawn();
		}
	}

	public void StopSpawn() {
		foreach(AsteroidSpawner spawner in mSpawnerList) {
			spawner.StopSpawn();
		}
	}
}
