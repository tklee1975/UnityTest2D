using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMain : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AsteroidManager.Instance.StartStateMain();
		AsteroidManager.Audio.PlayGameMusic();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
