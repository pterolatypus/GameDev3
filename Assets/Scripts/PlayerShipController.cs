using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    [SerializeField]
    private Ship ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //NOTE: this may be bad for performance, check it later
        GameObject prop = ship.GetSubsystem(Subsystem.Propulsion);
        PropulsionSystem propSys = prop.GetComponent<PropulsionSystem>();

        float throttle = Input.GetAxis("Throttle");
        propSys.SetThrottle(throttle);

        float pitch = Input.GetAxis("Pitch");
        float roll = Input.GetAxis("Roll");
        float yaw = Input.GetAxis("Yaw");
        propSys.SetRotationInput(new Vector3(pitch, roll, yaw));

        float forward = Input.GetAxis("Forward");
        float right = Input.GetAxis("Right");
        float up = Input.GetAxis("Up");
        propSys.SetTranslationInput(new Vector3(right, up, forward));

        if (Input.GetButtonDown("Dampeners")) {
            propSys.ToggleDampeners();
        }


	}
}
