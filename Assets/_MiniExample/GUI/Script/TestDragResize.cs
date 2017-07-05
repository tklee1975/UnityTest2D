using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TestDragResize : MonoBehaviour, IPointerDownHandler, IDragHandler {
	private RectTransform mDialogRect;
	private RectTransform mCanvasRect;

	private Vector3 mOriginDialogPos;	// Local position
	private Vector2 mPointerStartPos;	// local position 
	private Vector2 mOriginSizeDelta;

	public Vector2 minSize = new Vector2 (100, 100);
	public Vector2 maxSize = new Vector2 (400, 400);



	// Use this for initialization
	void Start () {

	}

	void Awake () {
		mDialogRect = transform.parent as RectTransform;
		mCanvasRect = mDialogRect.parent as RectTransform;
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerDown (PointerEventData data) {
		Debug.Log("TestDragResize: OnPointerDown: data=" + data);
		// Save the original Size delta
		mOriginSizeDelta = mDialogRect.sizeDelta;

		// Debug.Log("OnPointerDown: data=" + data);
		// Save the original Position 
		RectTransformUtility.ScreenPointToLocalPointInRectangle (mCanvasRect, 
			data.position, data.pressEventCamera, out mPointerStartPos);
	}

	public void OnDrag (PointerEventData data) {
		Debug.Log("TestDragResize: OnDrag: data=" + data);

		if (mDialogRect == null) {
			return;
		}

		Vector2 pointerPos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (
			mDialogRect, data.position, data.pressEventCamera, out pointerPos);


		Vector3 offsetToOriginal = pointerPos - mPointerStartPos;
		Vector2 sizeDelta = mOriginSizeDelta + new Vector2 (offsetToOriginal.x, -offsetToOriginal.y);


		sizeDelta = new Vector2 (
			Mathf.Clamp (sizeDelta.x, minSize.x, maxSize.x),
			Mathf.Clamp (sizeDelta.y, minSize.y, maxSize.y)
		);

		mDialogRect.sizeDelta = sizeDelta;

		// ClampToWindow ();
	}

//	void ClampToWindow () {
//		Vector3 pos = mDialogRect.localPosition;
//
//		Vector3 minPosition = mCanvasRect.rect.min - mDialogRect.rect.min;
//		Vector3 maxPosition = mCanvasRect.rect.max - mDialogRect.rect.max;
//
//		pos.x = Mathf.Clamp (mDialogRect.localPosition.x, minPosition.x, maxPosition.x);
//		pos.y = Mathf.Clamp (mDialogRect.localPosition.y, minPosition.y, maxPosition.y);
//
//		mDialogRect.localPosition = pos;
//	}
}
