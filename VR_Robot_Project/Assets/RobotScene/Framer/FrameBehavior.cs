using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBehavior : MonoBehaviour {

	GameObject[] defaultParts;
	GameObject[] parts;

	// Use this for initialization
	void Start () {
		parts = new GameObject[transform.childCount];
		defaultParts = new GameObject[transform.childCount];
		for (int i = 0; i < parts.Length; i++) {
			parts[i] = gameObject.transform.GetChild(i).gameObject;
			defaultParts[i] = gameObject.transform.GetChild(i).gameObject;
		}
	}

	void OnCollisionEnter(Collision collision) {
		GameObject other = collision.gameObject;
		GameObject myFramePiece = (collision.contacts [0].thisCollider.gameObject);

		//This prevents replacement of placed part
		/*bool endEarly = true;
		foreach (GameObject g in defaultParts) {
			if (g == myFramePiece) {
				endEarly = false;
				break;
			}
		}
		if (endEarly) {
			return;
		}*/

		if (other.tag == "RobotPart" && !hasPart(other)) {
			int n = IndexOf (myFramePiece);
			other.transform.position = myFramePiece.transform.position;
			other.transform.rotation = myFramePiece.transform.rotation;
			other.transform.SetParent (gameObject.transform);
			other.name = myFramePiece.name;
			Destroy (other.GetComponent<HeldObject> ());
			Destroy (other.GetComponent<Rigidbody> ());
			Destroy(myFramePiece);
			parts [n] = other;
		}
	}

	public bool hasPart(GameObject g) {
		for (int i = 0; i < parts.Length; i++) {
			if (parts [i] == g) {
				return true;
			}
		}
		return false;
	}

	int IndexOf(GameObject g) {
		for (int i = 0; i < parts.Length; i++) {
			if (g == parts [i]) {
				return i;
			}
		}
		return -1;
	}
}
