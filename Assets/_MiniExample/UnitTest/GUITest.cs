using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class GUITest : BaseTest {

	private Dialog mAlertDialog;

	void Start() {
		GameObject gObj;

		gObj = GameObject.Find("AlertDialog");
		mAlertDialog = gObj.GetComponent<Dialog>();
	}

	[Test]
	public void ShowAlert()
	{
		mAlertDialog.ShowDialog();
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}

	public void ButtonTestMethod() {
		Debug.Log("Button is clicked");
	}
}
