using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMain : MonoBehaviour {
	private AsteroidSpace mAsteroidSpace;

	// Use this for initialization
	void Start () {
		mAsteroidSpace = GameObject.Find("AsteroidSpace").GetComponent<AsteroidSpace>();

		StartGame();

		// Checking
		Debug.Log("AsteroidSpace=" + mAsteroidSpace);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame()
	{
		mAsteroidSpace.StartSpawn();
	}
}
