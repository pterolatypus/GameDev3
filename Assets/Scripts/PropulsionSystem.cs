using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionSystem : MonoBehaviour {

    private ThrusterPair[] thrusterPairs;
    
    private bool inertialDampener;
    private float throttleInput;
    private Vector3 rotationInput, translationInput;

	// Use this for initialization
	void Start () {
        thrusterPairs = gameObject.GetComponentsInChildren<ThrusterPair>();

	}

    public void ToggleDampeners() {
        inertialDampener = !inertialDampener;
    }

    public void SetThrottle(float throttle) {
        this.throttleInput = throttle;
    }

    public void SetRotationInput(Vector3 rot) {
        this.rotationInput = rot;
    }

    public void SetTranslationInput(Vector3 trn) {
        this.translationInput = trn;
    }

    void FixedUpdate() {
        foreach (ThrusterPair pair in thrusterPairs) {
            Vector3 lUp = transform.InverseTransformVector(pair.transform.up);
            float mag = Vector3.Dot(lUp, translationInput);
            pair.SetThrust(mag);
        }
    }
}
