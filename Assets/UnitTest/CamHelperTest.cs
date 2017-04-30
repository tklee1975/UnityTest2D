using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class CamHelperTest : BaseTest {
	public Bounds bound;

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(bound.center, bound.size);
	}

	[Test]
	public void ResizeBound()
	{
		bound = new Bounds(Vector3.zero, new Vector3(3, 3, 0));
	}

	[Test]
	public void TestCameraBounds()
	{
		bound = CamHelper.getCameraBounds();
	}
}
