using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AsteroidUITest : BaseTest {
	private AsteroidUI mAsteroidUI;
	public int score = 0;
	public int life = 1;

	void Start() {
		mAsteroidUI = GameObject.Find("AsteroidUI").GetComponent<AsteroidUI>();	

		mAsteroidUI.SetOnPlayCallback(OnPlayClick);
	}

	public void OnPlayClick(bool isPlayAgain)
	{
		Debug.Log("OnPlayClick: playAgain=" + isPlayAgain);
	}

	[Test]
	public void ShowMain()
	{
		mAsteroidUI.ShowMainUI(2233);
	}

	[Test]
	public void HideMain()
	{
		mAsteroidUI.HideMainUI();
	}

	[Test]
	public void ShowGame()
	{
		mAsteroidUI.ShowGameUI();
	}

	[Test]
	public void HideGame()
	{
		mAsteroidUI.HideGameUI();
	}

	[Test]
	public void ShowGameEnd()
	{
		mAsteroidUI.ShowGameEndUI(123, 1234);
	}

	[Test]
	public void HideGameEnd()
	{
		mAsteroidUI.HideGameEndUI();
	}

	[Test]
	public void SetLife()
	{
		life = life + 1;
		mAsteroidUI.SetLife(life);
	}

	[Test]
	public void SetScore()
	{
		score += 100;
		mAsteroidUI.SetScore(score);
	}
}
