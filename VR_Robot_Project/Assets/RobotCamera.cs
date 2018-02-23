using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCamera : MonoBehaviour {

	GameObject robotFrame;

	// Use this for initialization
	void Start () {
		robotFrame = GameObject.FindObjectOfType<FrameBehavior> ().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = robotFrame.transform.position + new Vector3 (0, 1, 0);
		transform.rotation = robotFrame.transform.rotation;
	}
}
