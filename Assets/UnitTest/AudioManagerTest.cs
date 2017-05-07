using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class AudioManagerTest : BaseTest {
	[Test]
	public void PlayBGM()
	{
		AsteroidManager.Audio.PlayGameMusic();
	}

	[Test]
	public void StopBGM()
	{
		AsteroidManager.Audio.StopGameMusic();
	}

	[Test]
	public void PlayButtonClick()
	{
		AsteroidManager.Audio.PlayUIClick();
	}

	[Test]
	public void PlayFireMissile()
	{
		AsteroidManager.Audio.PlayFire();
	}

	[Test]
	public void PlayAsteroidHit()
	{
		AsteroidManager.Audio.PlayAsteroidHit();
	}

	[Test]
	public void PlayShipHit()
	{
		AsteroidManager.Audio.PlayShipHit();
	}

}
