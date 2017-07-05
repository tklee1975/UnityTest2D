using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {
	private Vector3 mOutScreenPosition;

	// Use this for initialization
	void Start () {
		//Screen.w
		mOutScreenPosition = new Vector3(Screen.width, Screen.height, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowDialog() {
		transform.localPosition = Vector3.zero;
	}

	public void CloseDialog() {
		transform.localPosition = mOutScreenPosition;
	}
}
