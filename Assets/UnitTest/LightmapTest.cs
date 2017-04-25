using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class LightmapTest : BaseTest {
	private GameObject mLight;

	void Start() {
		mLight = GameObject.Find("earth/Point light");
	}

	[Test]
	public void ToggleLight()
	{
		if(mLight.activeSelf) {
			mLight.SetActive(false);
		} else {
			mLight.SetActive(true);
		}
	}
}
