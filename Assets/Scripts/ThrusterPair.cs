using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterPair : MonoBehaviour {

    [SerializeField]
    public float thrust;
    private Thruster positive, negative;

	// Use this for initialization
	void Start () {
        Thruster[] children = gameObject.GetComponentsInChildren<Thruster>();
        foreach (Thruster child in children) {
            if (child.transform.up == transform.up) {
                negative = child;
            } else {
                positive = child;
            }
        }
	}

    public void SetThrust(float thrust) {
        this.thrust = thrust;
        positive.SetThrust(Mathf.Clamp(thrust, 0f, 1f));
        negative.SetThrust(-Mathf.Clamp(thrust, 0f, -1f));
    }
}
