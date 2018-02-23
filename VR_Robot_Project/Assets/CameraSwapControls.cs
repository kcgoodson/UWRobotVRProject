using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwapControls : MonoBehaviour {

	public GameObject roboCam;

	public void Switch() {
		roboCam.SetActive (!roboCam.activeSelf);
		if (roboCam.activeSelf) {
			GetComponentInChildren<Text> ().text = "Human View";
		} else {
			GetComponentInChildren<Text> ().text = "Robot View";
		}
	}
}
