using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	#region Game Spesific

	#endregion

	#region Template Fields
	public AudioSource musicSource;
	public AudioSource soundSource;

	public AudioClip gameMusic;
	public AudioClip uiClick;
	public AudioClip fireMissile;
	public AudioClip asteroidHit;
	public AudioClip shipHit;
	#endregion

	#region Sound FX Methods
	public void PlayUIClick()
	{
		soundSource.clip = uiClick;
		soundSource.Play ();
	}

	public void PlayFire()
	{
		soundSource.clip = fireMissile;
		soundSource.Play();
	}

	public void PlayAsteroidHit()
	{
		soundSource.clip = asteroidHit;
		soundSource.Play();
	}

	public void PlayShipHit()
	{
		soundSource.clip = shipHit;
		soundSource.Play();
	}

	public void SetSoundFxVolume(float value)
	{
		float temp = value + soundSource.volume;
		if (temp < 0 || temp > 1)
			return;
		else
			soundSource.volume += value;
	}
	#endregion

	#region Music Methods
	public void PlayGameMusic()
	{
		musicSource.clip = gameMusic;
		musicSource.Play ();
	}

	public void StopGameMusic()
	{
		musicSource.Stop ();
	}

	public void SetSoundMusicVolume(float value)
	{
		float temp = value + musicSource.volume;
		if (temp < 0 || temp > 1)
			return;
		else
			musicSource.volume += value;
	}
	#endregion

}


