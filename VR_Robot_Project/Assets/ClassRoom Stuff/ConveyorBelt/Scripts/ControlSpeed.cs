using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpeed : MonoBehaviour {
	ConveyorScript myConveyorScript;
	// Use this for initialization
	void Start () {
		myConveyorScript = GetComponent<ConveyorScript>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M))
		myConveyorScript.enabled = !myConveyorScript.enabled;
	}
}
