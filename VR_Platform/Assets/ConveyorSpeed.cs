using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpeed : MonoBehaviour {
	ConveyorScript myConveyorScript;
	// Use this for initialization
	void Start () {
		myConveyorScript = GetComponent<ConveyorScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			myConveyorScript.enabled = !myConveyorScript.enabled;
	}
}
