using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

    [SerializeField]
    private float maxThrust, thrustResponse;
    private float currentThrust, targetThrust, dThrust;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponentInParent<Ship>().GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetThrust(float target) {
        targetThrust = target;
    }

    void FixedUpdate() {
        //Update current thrust level
        float smoothTime = Mathf.Abs(currentThrust - targetThrust)*thrustResponse;
        currentThrust = Mathf.SmoothDamp(currentThrust, targetThrust, ref dThrust, smoothTime);

        Vector3 force = maxThrust * currentThrust * new Vector3(0, -1, 0);
        rb.AddForceAtPosition(force, transform.parent.localPosition);
    }
}