using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCamera : MonoBehaviour {

	GameObject robotFrame;

	// Use this for initialization
	void Start () {
		robotFrame = GameObject.FindObjectOfType<FrameBehavior> ().gameObject.transform.Find("Eyeball").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = robotFrame.transform.position;// + new Vector3 (0, 1, 0) + robotFrame.transform.forward/2;
		transform.rotation = robotFrame.transform.rotation;
	}
}
