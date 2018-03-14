using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour {

	Vector3[] directions = new Vector3[]{Vector3.forward, Vector3.left, Vector3.back, Vector3.right, Vector3.up, Vector3.down};
	KeyCode[] keys = new KeyCode[]{KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.U, KeyCode.O};
	public float speed = 30;
	//public float buffer = 0f;
	//public int player;
	//string[] keys;

	public Controller left;
	public Controller right;
	public GameObject head;

	public Text bugger;

	// Update is called once per frame*/
	void Update () {
		Vector3 sum = new Vector3 ();

		float sumVertical = 0f;

		Vector2 leftV = new Vector2();
		if (left != null && left.gameObject.activeSelf) {
			if (left.controller.GetPress (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
				leftV = left.controller.GetAxis ();
			}
			if (left.controller.GetPress (Valve.VR.EVRButtonId.k_EButton_Grip)) {
				sumVertical += 0.5f;
			}
		}

		Vector2 rightV = new Vector2();
		if (right != null && right.gameObject.activeSelf) {
			if (right.controller.GetPress (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
				rightV = right.controller.GetAxis ();
			}
			if (right.controller.GetPress (Valve.VR.EVRButtonId.k_EButton_Grip)) {
				sumVertical -= 0.5f;
			}
		}

		float sumX = leftV.x + rightV.x;
		float sumY = leftV.y + rightV.y;



		sum = myForward + myRight;

		//bugger.text = "SUMX: " + sumX + "\nSUMY: " + sumY;
		transform.Translate (sum * speed * Time.deltaTime);
	}
	//*/
}
