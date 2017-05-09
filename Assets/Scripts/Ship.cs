using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Subsystem {
    Propulsion
}

public class Ship : MonoBehaviour {

    private Dictionary<Subsystem, GameObject> systems = new Dictionary<Subsystem, GameObject>();

    // Use this for initialization
    void Start () {
        systems.Add(Subsystem.Propulsion, GetComponentInChildren<PropulsionSystem>().gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetSubsystem(Subsystem sys) {
        if (systems.ContainsKey(sys)) {
            return systems[sys];
        }
        else return null;
    }
}
