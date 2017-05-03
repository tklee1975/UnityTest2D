using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AsteroidManagerTest : BaseTest {
	[Test]
	public void QuickTest()
	{
		AsteroidManager.TestMe();
	}

	[Test]
	public void ShowMainUI()
	{
		AsteroidManager.Instance.UI.ShowMainUI(1234);
	}

	[Test]
	public void StartMain()
	{
		AsteroidManager.Instance.StartStateMain();
	}

	[Test]
	public void StartGame()
	{
		AsteroidManager.Instance.StartStateGame();
	}

	[Test]
	public void StartGameEnd()
	{
		AsteroidManager.Instance.StartStateGameEnd();
	}
}
