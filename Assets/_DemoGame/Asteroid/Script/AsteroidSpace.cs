using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpace : MonoBehaviour {
	public Bounds bound = new Bounds(new Vector3(0, 2, 0), new Vector3(15, 10, 0));

	List<AsteroidSpawner> mSpawnerList = new List<AsteroidSpawner>();

	private PlayerShip mPlayerShip;

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

		mPlayerShip = transform.Find("PlayerShip").GetComponent<PlayerShip>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPlayerActive(bool flag) {
		mPlayerShip.gameObject.SetActive(flag);
	}

	public void ResetPlayer() {
		Debug.Log("ResetPlayer!!!");
		mPlayerShip.transform.position = Vector3.zero;
		mPlayerShip.isHitting = false;
	}

	public void StartGame() {
		Debug.Log("StartGame!!!");
		SetPlayerActive(true);
		ResetPlayer();
		StartSpawn();
	}

	public void StopGame() {
		SetPlayerActive(false);
		StopSpawn();

		GameObject[] objList = GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject o in objList) {
			GameObject.Destroy(o);
		}
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
