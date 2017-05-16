using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBehaviour : MonoBehaviour {
	public GameObject exploreParticle;

	public void ShowExplosion()
	{
		if(exploreParticle == null) {
			return;
		}

		GameObject obj = Instantiate(exploreParticle, transform.position, transform.rotation);
		float duration = obj.GetComponent<ParticleSystem>().main.duration;
		Destroy(obj, duration);
	}

}
