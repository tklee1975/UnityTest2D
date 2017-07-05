using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TestDragObject : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler {

	private Dictionary<int,GameObject> mDraggingIcons = new Dictionary<int, GameObject>();
	private Dictionary<int, RectTransform> mDraggingPlanes = new Dictionary<int, RectTransform>();
	public bool dragOnSurfaces = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("OnBeginDrag: event=" + eventData);	

		// Find the Top Canvas holding the given game object
		Canvas canvas = FindInParents<Canvas>(gameObject);
		if (canvas == null) {
			return;
		}

		// We have clicked something that can be dragged.
		// What we want to do is create an icon for this.
		GameObject dragObject = new GameObject("icon");
		dragObject.transform.SetParent (canvas.transform, false);
		dragObject.transform.SetAsLastSibling();

		Image image = dragObject.AddComponent<Image>();
		image.sprite = GetComponent<Image>().sprite;
		image.SetNativeSize();

		mDraggingIcons[eventData.pointerId] = dragObject;

		if (dragOnSurfaces) {
			mDraggingPlanes[eventData.pointerId] = transform as RectTransform;			// Drag object transform
		} else {
			mDraggingPlanes[eventData.pointerId] = canvas.transform as RectTransform;	// the top canvas transform 
		}
	
		SetDraggedPosition(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
//		if (m_DraggingIcons[eventData.pointerId] != null)
//			SetDraggedPosition(eventData);
		Debug.Log("OnDrag: event=" + eventData);

		if (mDraggingIcons[eventData.pointerId] != null) {
			SetDraggedPosition(eventData);
		}
	}

	private void SetDraggedPosition(PointerEventData eventData)
	{
		if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
			mDraggingPlanes[eventData.pointerId] = eventData.pointerEnter.transform as RectTransform;

		RectTransform rt = mDraggingIcons[eventData.pointerId].GetComponent<RectTransform>();

		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(mDraggingPlanes[eventData.pointerId], 
									eventData.position, eventData.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			rt.rotation = mDraggingPlanes[eventData.pointerId].rotation;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("OnEndDrag: event=" + eventData);
	}


	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();

		if (comp != null) {
			return comp;
		}

		var t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
}
