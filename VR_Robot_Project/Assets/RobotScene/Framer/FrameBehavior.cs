using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBehavior : MonoBehaviour {

	//GameObject[] defaultParts;
	//GameObject[] parts;
	public List<GameObject> parts;
	public GameObject frameBall;

	// Use this for initialization
	void Start () {
		parts = new List<GameObject> ();
		//defaultParts = new GameObject[transform.childCount];
		/*for (int i = 0; i < parts.Length; i++) {
			parts[i] = gameObject.transform.GetChild(i).gameObject;
			//defaultParts[i] = gameObject.transform.GetChild(i).gameObject;
		}
		///*/
	}

	/*void Update() {
		if (Input.GetKey (KeyCode.Y)) {
			for (int i = 0; i < parts.Count; i+=0) {
				Delete(parts [i]);
				//parts.RemoveAt (i);
			}
		}
	}
	//*/

	void OnCollisionEnter(Collision collision) {
		
		GameObject myFramePiece = (collision.contacts [0].thisCollider.gameObject);

		/*This prevents replacement of placed part
		bool endEarly = true;
		foreach (GameObject g in defaultParts) {
			if (g == myFramePiece) {
				endEarly = false;
				break;
			}
		}
		if (endEarly) {
			return;
		}
		//This prevents replacement of placed part*/

		if (myFramePiece.tag != "FrameBall") {
			return;
		}

		GameObject other = collision.gameObject;
		if (other.tag == "RobotPart" && !hasPart(other)) {
			//int n = IndexOf (myFramePiece);
			other.transform.position = myFramePiece.transform.position;
			other.transform.rotation = myFramePiece.transform.rotation;
			other.transform.localScale = myFramePiece.transform.lossyScale;
			other.transform.SetParent (gameObject.transform);
			other.name = myFramePiece.name;
			other.tag = "PartOfRobot";
			Destroy (other.GetComponent<HeldObject> ());
			Destroy (other.GetComponent<Rigidbody> ());
			Destroy(myFramePiece);
			parts.Add (other);
			//parts [n] = other;
		}
	}

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
