using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpeed : MonoBehaviour {
	ConveyorScript myConveyorScript;
	// Use this for initialization
	public void Start () {
		myConveyorScript = GetComponent<ConveyorScript>();
	}

	// Update is called once per frame
	public void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
		myConveyorScript.enabled = !myConveyorScript.enabled;
	}
}
