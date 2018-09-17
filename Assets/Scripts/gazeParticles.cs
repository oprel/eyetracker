using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

[RequireComponent(typeof(GazeAware),typeof(ParticleSystem))]

public class gazeParticles : MonoBehaviour {

    private GazeAware aware;
    private ParticleSystem.EmissionModule ps;
	private float baserate;

	void Awake () {
        aware = GetComponent<GazeAware>();
		ps = GetComponent<ParticleSystem>().emission;
		ps.rateOverTimeMultiplier=0;
    }
	
	void Update () {
		if(aware.HasGazeFocus) {
			ps.rateOverTimeMultiplier = Mathf.Lerp(ps.rateOverTimeMultiplier,1,.1f);
        }
        else {
            ps.rateOverTimeMultiplier = Mathf.Lerp(ps.rateOverTimeMultiplier,0,.3f);
        }
	}
}
