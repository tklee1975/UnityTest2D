using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestDragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private RectTransform mDialogRect;
	private RectTransform mCanvasRect;

	private Vector3 mOriginDialogPos;	// Local position
	private Vector2 mPointerStartPos;	// local position 


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
		Debug.Log("TestDragPanel: OnPointerDown: data=" + data);
		// Debug.Log("OnPointerDown: data=" + data);
		mOriginDialogPos = mDialogRect.localPosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (mCanvasRect, 
			data.position, data.pressEventCamera, out mPointerStartPos);
	}

	public void OnDrag (PointerEventData data) {
		//Debug.Log("OnDrag: data=" + data);

		if (mDialogRect == null || mCanvasRect == null) {
			return;
		}

		Vector2 pointerPos;
		bool isHit = RectTransformUtility.ScreenPointToLocalPointInRectangle (
			mCanvasRect, data.position, data.pressEventCamera, out pointerPos);
		if(isHit) {
			Vector3 offsetToOriginal = pointerPos - mPointerStartPos;
			mDialogRect.localPosition = mOriginDialogPos + offsetToOriginal;
		}

		ClampToWindow ();
	}

	void ClampToWindow () {
		Vector3 pos = mDialogRect.localPosition;

		Vector3 minPosition = mCanvasRect.rect.min - mDialogRect.rect.min;
		Vector3 maxPosition = mCanvasRect.rect.max - mDialogRect.rect.max;

		pos.x = Mathf.Clamp (mDialogRect.localPosition.x, minPosition.x, maxPosition.x);
		pos.y = Mathf.Clamp (mDialogRect.localPosition.y, minPosition.y, maxPosition.y);

		mDialogRect.localPosition = pos;
	}
}
