using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioManager))]
public class AsteroidManager : MonoBehaviour {


	public AsteroidUI UI = null;
	public AsteroidSpace PlaySpace = null;

	private static AudioManager mAudioManager;
	public static AudioManager Audio
	{
		get { return mAudioManager; }
	}


	private int mLife = 0;
	public int Life {
		set { mLife = value; }
		get { return mLife; }
	}

	private int mScore = 0;
	public int Score {
		set { mScore = value; }
		get { return mScore; }
	}

	private int mBestScore = 0;
	public int BestScore {
		set { mBestScore = value; }
		get { return mBestScore; }
	}

	// Singleton Pattern
	private static AsteroidManager mInstance = null;
	public static AsteroidManager Instance 
	{
		get { return mInstance; }
	}

	private void SetupSingleton()
	{
		if(mInstance == null) {
			mInstance = this;
		}

		mAudioManager = GetComponent<AudioManager>();

		DontDestroyOnLoad(gameObject);	// note: AsteroidManager rely on the GameObject
	}

	public void ResetGame()
	{
		mLife = 3;
		mScore = 0;

		UI.SetLife(mLife);
		UI.SetScore(mScore);
		UI.SetBestScore(mBestScore);
		//UI.SetBestScore(mBestScore);
	}



	public void HandlePlayerHit() {
		Debug.Log("HandlePlayerHit");
		mLife--;
		UI.SetLife(mLife);

		// 
		if(mLife > 0) {
			PlaySpace.ResetPlayer();
			return;
		}

		StartStateGameEnd();
	}

	public void HandleEnemyHit() {
		mScore += 10;
		UI.SetScore(mScore);

		if(mScore > mBestScore) {
			mBestScore = mScore;
			UI.SetBestScore(mBestScore);
		}
	}


	// Different State Handling 

	public void StartStateMain() {
		PlaySpace.StopGame();
		UI.ShowMainUI(mBestScore);
	}

	public void StartStateGame() {

		ResetGame();

		UI.ShowGameUI();
		PlaySpace.StartGame();
	}

	public void StartStateGameEnd() {
		//PlaySpace.Star
		PlaySpace.StopGame();
		UI.ShowGameEndUI(mScore, mBestScore);
	}


	public void OnPlayClicked(bool isPlayAgain) {
		Debug.Log("onPlqyClicked. isPlayAgain=" + isPlayAgain);
		StartStateGame();
	}

	// 

	void Awake ()
	{
		SetupSingleton();

		if(UI != null) {
			UI.SetOnPlayCallback(OnPlayClicked);
		}
	}

	// 

	public static void TestMe() {
		Debug.Log("AsteroidManager: Hello Game Developer!");
	}
}
