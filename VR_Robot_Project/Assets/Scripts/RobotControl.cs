using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour {

	Rigidbody myBody;
	public float rotateSpeed;
	public float speed;
	public string[] keys;

	void Start() {
		myBody = GetComponent<Rigidbody> ();
		keys = new string[5];
		for (int i = 0; i < keys.Length; i++) {
			keys [i] = "player1_" + i;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Controls Forward and Backward Movement
		int direction = 0;
		if (Input.GetButton (keys [0])) {
			direction = 1;
		} else if (Input.GetButton (keys [2])) {
			direction = -1;
		}
		if (direction != 0) {
			Vector3 newDirection = (transform.forward * speed * direction);
			newDirection.y = myBody.velocity.y;
			myBody.velocity = newDirection;
			//myBody.AddForce(transform.forward*speed*direction*myBody.mass);
		}

		//Controls Rotation
		direction = 0;
		if (Input.GetButton (keys [1])) {
			direction = -1;
		} else if (Input.GetButton (keys [3])) {
			direction = 1;
		}
		myBody.angularVelocity = rotateSpeed * direction * transform.up;
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		//Plays AudioClip
		if(Input.GetButtonDown(keys[4])) {
			GetComponent<AudioSource> ().Play ();
		}

	}
}
