using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using DG.Tweening;

// http://dotween.demigiant.com/documentation.php#shortcuts

// http://easings.net/
public class DOTweenTest : BaseTest {
	private GameObject mStar;
	private GameObject mGameOverDialog;
	private Text[] mEaseLabel = new Text[3];

	void Start() {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		mStar = GameObject.Find("Star");

		// 
		mEaseLabel[0] = GameObject.Find("Label1").GetComponent<Text>();
		mEaseLabel[1] = GameObject.Find("Label2").GetComponent<Text>();
		mEaseLabel[2] = GameObject.Find("Label3").GetComponent<Text>();
		foreach(Text text in mEaseLabel) {
			text.text = "";
		}

		// 
		mGameOverDialog = GameObject.Find("GameOverDialog");
	}

	[Test]
	public void startTween()
	{
		Transform star = mStar.transform;
		setTransformX(star, -5);
		star.DOMoveX(-3, 1).SetLoops(-1, LoopType.Yoyo);
	}

	[Test]
	public void stopTween()
	{
		Transform star = mStar.transform;

		star.DOKill();
	}

	[Test]
	public void PauseTween()
	{
		Transform star = mStar.transform;

		star.DOPause();
	}

	[Test]
	public void PlayTween()
	{
		Transform star = mStar.transform;

		star.DOPlay();
	}



	[Test]
	public void showDialog()
	{
		Tweener tweener = mGameOverDialog.GetComponent<RectTransform>().DOAnchorPosY(-300, 0.5f, true);
		tweener.SetEase(Ease.OutBack);
	}

	[Test]
	public void closeDialog()
	{
		Tweener tweener = mGameOverDialog.GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f, true);
		tweener.SetEase(Ease.InBack );
	}



	[Test]
	public void testMove()
	{
		Transform star = mStar.transform;
		Vector3 startPos = new Vector3(0, 0, 0);

		star.position = startPos;

		Vector3 newPos = new Vector3(2, 2, 0);
		star.DOMove(newPos, 1);
	}

	[Test]
	public void testMoveX()
	{
		Transform star = mStar.transform;
		Vector3 startPos = new Vector3(0, 0, 0);
		star.position = startPos;

		star.DOMoveX(2, 1);	// px=2, time=1 sec
		star.DORestart();
		DOTween.Play(star.gameObject);

		//
	}

	[Test]
	public void testGeneric()
	{
		Transform star = mStar.transform;
		Vector3 startPos = new Vector3(1, 0, 0);
		star.position = startPos;


		DOTween.To( () => star.position, 	 // getter
					 p => star.position = p, // setter
			 		 new Vector3(5,1,0),  	 // target position
					 1);				 // duration 

	}

	void setTransformX(Transform transform, float x)
	{
		Vector3 pos = transform.position;

		pos.x = x;

		transform.position = pos;
	}

	void SetLabel(int index, string labelStr)
	{
		mEaseLabel[index].text = labelStr;
	}

	[Test]
	public void testSineEase()
	{
		
		Transform star1 = GameObject.Find("Star1").transform;
		Transform star2 = GameObject.Find("Star2").transform;
		Transform star3 = GameObject.Find("Star3").transform;

		setTransformX(star1, -5);
		setTransformX(star2, -5);
		setTransformX(star3, -5);

		float duration = 2.0f;

		SetLabel(0, "InSine");
		star1.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InSine);

		SetLabel(1, "InOutSine");
		star2.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InOutSine);

		SetLabel(2, "OutSine");
		star3.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.OutSine);
	}

	[Test]
	public void testBackEase()
	{

		Transform star1 = GameObject.Find("Star1").transform;
		Transform star2 = GameObject.Find("Star2").transform;
		Transform star3 = GameObject.Find("Star3").transform;

		setTransformX(star1, -5);
		setTransformX(star2, -5);
		setTransformX(star3, -5);

		float duration = 2.0f;

		SetLabel(0, "InBack");
		star1.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InBack);

		SetLabel(1, "InOutBack");
		star2.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InOutBack);

		SetLabel(2, "OutBack");
		star3.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.OutBack);
	}

	[Test]
	public void testBounceEase()
	{

		Transform star1 = GameObject.Find("Star1").transform;
		Transform star2 = GameObject.Find("Star2").transform;
		Transform star3 = GameObject.Find("Star3").transform;

		setTransformX(star1, -5);
		setTransformX(star2, -5);
		setTransformX(star3, -5);

		float duration = 2.0f;

		SetLabel(0, "InBounce");
		star1.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InBounce);

		SetLabel(1, "InOutBounce");
		star2.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InOutBounce);

		SetLabel(2, "OutBounce");
		star3.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.OutBounce);
	}

	[Test]
	public void testElasticEase()
	{

		Transform star1 = GameObject.Find("Star1").transform;
		Transform star2 = GameObject.Find("Star2").transform;
		Transform star3 = GameObject.Find("Star3").transform;

		setTransformX(star1, -5);
		setTransformX(star2, -5);
		setTransformX(star3, -5);

		float duration = 2.0f;

		SetLabel(0, "InElastic");
		star1.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InElastic);

		SetLabel(1, "InOutElastic");
		star2.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.InOutElastic);

		SetLabel(2, "OutElastic");
		star3.DOMoveX(0, duration).SetDelay(1).SetEase(Ease.OutElastic);
	}

	[Test]
	public void testCallback()
	{
		Transform star = mStar.transform;
		Vector3 startPos = new Vector3(0, 0, 0);
		star.position = startPos;


		DOTween.To( () => star.position, 	 // getter
			p => star.position = p, // setter
			new Vector3(4,3,0),  	 // target position
			1).OnComplete( () => {
				Debug.Log("OnComplete!!");
			});				 // duration 

	}
}
