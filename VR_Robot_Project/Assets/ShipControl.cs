using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

	Vector3[] directions = new Vector3[]{Vector3.forward, Vector3.left, Vector3.back, Vector3.right, Vector3.up, Vector3.down};
	//KeyCode[] keys = new KeyCode[]{KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.E};
	public float speed = 30;
	public int player;
	string[] keys;

	void Start() {
		keys = new string[6];
		for (int i = 0; i < keys.Length; i++) {
			keys [i] = "player" + player + "_" + i;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 sum = new Vector3 ();
		for (int i = 0; i < keys.Length; i++) {
			if (Input.GetButton(keys[i])) {
				sum += directions [i];
			}
		}
		sum = sum.normalized;
		transform.Translate (sum * speed * Time.deltaTime);
	}
}
