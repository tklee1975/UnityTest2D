using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidUI : MonoBehaviour {
	private GameObject mMainPanel = null;
	private GameObject mGamePanel = null;
	private GameObject mGameEndPanel = null;
	private Text mScoreText;
	private Text mBestScoreText;
	private Text mLifeText;


	// Define the Delegate
	public delegate void OnPlayCallback(bool isPlayAgain);
	private OnPlayCallback mOnPlayCallback = null;


	// Use this for initialization
	void Start () {
		mScoreText = GameObject.Find("AsteroidUI/GamePanel/ScoreText").GetComponent<Text>();
		mBestScoreText = GameObject.Find("AsteroidUI/GamePanel/BestScoreText").GetComponent<Text>();
		mLifeText = GameObject.Find("AsteroidUI/GamePanel/LifeText").GetComponent<Text>();
	}

	//  Setting the Callback
	public void SetOnPlayCallback(OnPlayCallback _delegate)
	{
		mOnPlayCallback = _delegate;
	}

	// Doing the Callback
	private void DoSetOnPlayCallback(bool isPlayAgain) {
		if(mOnPlayCallback != null) {
			mOnPlayCallback(isPlayAgain);
		}
	}

	private void SetObjectText(GameObject parentObj, string textName, string newString)
	{
		Text text = parentObj.transform.Find(textName).GetComponent<Text>();
		text.text = newString;
	}

	public void PlayClicked() {
		DoSetOnPlayCallback(false);
	}

	public void PlayAgainClicked() {
		DoSetOnPlayCallback(true);
	}
		

	public void SetBestScore(int newScore)
	{
		mBestScoreText.text = string.Format("Best: {0}", newScore);
	}

	public void SetScore(int newScore)
	{
		mScoreText.text = string.Format("Score: {0}", newScore);
	}

	public void SetLife(int newLife)
	{
		mLifeText.text = string.Format("Life: {0}", newLife);
	}

	private GameObject GetMainPanel()
	{
		if(mMainPanel != null) {
			return mMainPanel;
		}

		mMainPanel = GameObject.Find("AsteroidUI/MainPanel");
		return mMainPanel;
	}

	private GameObject GetGamePanel()
	{
		if(mGamePanel != null) {
			return mGamePanel;
		}

		mGamePanel = GameObject.Find("AsteroidUI/GamePanel");
		return mGamePanel;
	}

	private GameObject GetGameEndPanel()
	{
		if(mGameEndPanel != null) {
			return mGameEndPanel;
		}

		mGameEndPanel = GameObject.Find("AsteroidUI/GameEndPanel");
		return mGameEndPanel;
	}

	private void HideGUI(GameObject obj)
	{
		Vector3 outSidePos = new Vector3(0, 1000, 0);
		obj.transform.localPosition = outSidePos;
	}

	private void ShowGUI(GameObject obj)
	{
		obj.transform.localPosition = Vector3.zero;
	}



	public void HideMainUI() {
		HideGUI(GetMainPanel());
	}

	public void ShowMainUI(int bestScore) {
		ShowGUI(GetMainPanel());
		HideGameUI();
		HideGameEndUI();

		// Update the GUI Score
		string scoreStr = string.Format("Best: {0}", bestScore);
		SetObjectText(GetMainPanel(), "BestScoreText", scoreStr);
	}


	public void HideGameUI() {
		HideGUI(GetGamePanel());
	}

	public void ShowGameUI() {
		ShowGUI(GetGamePanel());
		HideMainUI();
		HideGameEndUI();
	}

	public void HideGameEndUI() {
		HideGUI(GetGameEndPanel());
	}

	public void ShowGameEndUI(int lastScore, int bestScore) {
		ShowGUI(GetGameEndPanel());
		HideMainUI();
		HideGameUI();

		// Update the GUI Score
		GameObject myPanel = GetGameEndPanel();
		string scoreStr;
		scoreStr = string.Format("Score: {0}", lastScore);
		SetObjectText(myPanel, "ScoreText", scoreStr);

		scoreStr = string.Format("Best: {0}", bestScore);
		SetObjectText(myPanel, "BestScoreText", scoreStr);

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
