using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {
	public float rotateSpeed = 45;

	// Use this for initialization
	void Start () {
		
	}
	


	public void RotateLeft(float delta) {
		Vector3 angle = new Vector3(0, 0, rotateSpeed * delta);
		transform.Rotate(angle);
	}


	public void RotateRight(float delta) {
		Vector3 angle = new Vector3(0, 0, -rotateSpeed * delta);
		transform.Rotate(angle);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.LeftArrow)){
			RotateLeft(Time.deltaTime);
		}else if(Input.GetKey(KeyCode.RightArrow)){
			RotateRight(Time.deltaTime);
		}
	}
}
