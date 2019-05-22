using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour {

	GameObject frame;

	void Start() {
		frame = GameObject.FindObjectOfType<FrameBehavior> ().gameObject;
	}

	public void Change(float f) {
		frame.transform.localScale = new Vector3 (f, f, f);
	}
}
