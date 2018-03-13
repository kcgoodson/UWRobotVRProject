using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour {

	GameObject heldObject;
	Controller controller;

	Rigidbody simulator;

	// Use this for initialization
	void Start () {
		simulator = new GameObject ().AddComponent<Rigidbody> ();
		simulator.name = "simulator";
		simulator.transform.parent = transform.parent;

		controller = GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (heldObject) {
			simulator.velocity = (transform.position - simulator.position) * 50f;
			if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
				heldObject.GetComponent<Rigidbody> ().isKinematic = false;
				heldObject.GetComponent<Rigidbody> ().velocity = simulator.velocity;
				heldObject.GetComponent<HeldObject> ().parent = null;
				heldObject.transform.parent = null;
				heldObject = null;

			}
			
		} else {
			if(controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
				Collider[] cols = Physics.OverlapSphere (transform.position, 0.1f);
				FrameBehavior f = FindObjectOfType<FrameBehavior>();
				foreach (Collider c in cols) {
					if (heldObject == null && c.GetComponent<HeldObject> () && c.GetComponent<HeldObject> ().parent == null && !f.hasPart (c.gameObject)) {
						heldObject = c.gameObject;
						heldObject.transform.parent = transform;
						heldObject.transform.localPosition = Vector3.zero;
						heldObject.transform.localRotation = Quaternion.identity;
						heldObject.GetComponent<Rigidbody> ().isKinematic = true;
						heldObject.GetComponent<HeldObject> ().parent = controller;
						//Feb 22.5
					} else if (heldObject == null && c.gameObject.tag == "PartOfRobot") {
						GameObject.FindObjectOfType<FrameBehavior> ().Delete (c.gameObject);
						return;
					}
				}

			}
		}
		
	}

	public void ForceNullHeldObject() {
		heldObject = null;
	}

	public GameObject HandHeldObject() {
		return heldObject;
	}

	public void ShipMovement() {
		
	}
}
