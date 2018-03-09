using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBehavior : MonoBehaviour {

	public List<GameObject> parts;
	public GameObject frameBall;

	//Creates the empty list to keep track of the robot's current parts
	void Start () {
		parts = new List<GameObject> ();
	}

	// Press Y to Reset Frame
	void Update() {
		if (Input.GetKey (KeyCode.Y)) {
			for (int i = 0; i < parts.Count; i+=0) {
				Delete(parts [i]);
				//parts.RemoveAt (i);
			}
		}
	}
	//*/

	void OnCollisionEnter(Collision collision) {

		//Gets the Child Object that was hit
		GameObject myFramePiece = (collision.contacts [0].thisCollider.gameObject);

		//Ends the program if a non-FrameBall is hit
		if (myFramePiece.tag != "FrameBall") {
			return;
		}

		GameObject other = collision.gameObject;
		if (other.tag == "RobotPart" && !hasPart (other)) {

			Hand[] hands = GameObject.FindObjectsOfType<Hand> ();
			for (int i = 0; i < hands.Length; i++) {
				if (hands [i].HandHeldObject () == other) {
					hands [i].ForceNullHeldObject ();
				}
			}
				
			other.transform.position = myFramePiece.transform.position;
			other.transform.rotation = myFramePiece.transform.rotation;
			other.transform.localScale = myFramePiece.transform.lossyScale;
			other.transform.SetParent (gameObject.transform);
			other.name = myFramePiece.name;
			other.tag = "PartOfRobot";
			Destroy (other.GetComponent<HeldObject> ());
			Destroy (other.GetComponent<Rigidbody> ());
			Destroy (myFramePiece);
			parts.Add (other);
		} else if (other.tag == "LoneBall") {
			Destroy (other.GetComponent<HeldObject> ());
			Destroy (other.GetComponent<Rigidbody> ());
			other.transform.SetParent (gameObject.transform);
		}
	}

	//Turns a Robot Part back into a Frame Ball
	public void Delete(GameObject g) {
		int index = IndexOf (g);
		if (index != -1) {
			GameObject framePiece = Instantiate (frameBall);
			framePiece.transform.position = g.transform.position;
			framePiece.transform.rotation = g.transform.rotation;
			framePiece.transform.localScale = g.transform.lossyScale;
			framePiece.transform.SetParent (gameObject.transform);
			parts.Remove(g);
			Destroy (g);
		}
	}

	public bool hasPart(GameObject g) {
		return parts.Contains(g);
	}

	int IndexOf(GameObject g) {
		return parts.IndexOf (g);
	}
}
