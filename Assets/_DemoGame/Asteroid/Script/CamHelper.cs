using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHelper {

	public static Bounds getCameraBounds()
	{
		Camera camera = Camera.main;

		Vector3 botLeft = camera.ViewportToWorldPoint(new Vector3(0,0,0));
		Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1,1,0));

		//public Bounds bound = new Bounds(new Vector3(0, 2, 0), new Vector3(15, 10, 0));

		Vector3 size = new Vector3((topRight.x - botLeft.x), (topRight.y - botLeft.y), 0);

		Bounds bound = new Bounds(Vector3.zero, size);

		return bound;
	}
}
